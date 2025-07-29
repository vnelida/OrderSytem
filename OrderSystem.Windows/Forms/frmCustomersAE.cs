using Entities.Entities;
using Entities.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System.Data;
using System.Text.RegularExpressions;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmCustomersAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private List<AddressWithTypeVM> addresses = new();
        private List<PhonesWithTypeVM> phones = new();
        private List<Address> addressesList = new();
        private List<Phone> phonesList = new();
        private readonly ICustomersServices _customersService;
        Customer? customer;

        public frmCustomersAE(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _customersService = serviceProvider!.GetRequiredService<ICustomersServices>()
               ?? throw new ApplicationException("Dependencies for ICustomersServices not loaded");

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (customer != null) // Modo "Editar cliente existente"
            {
                txtFirstName.Text = customer.FirstName;
                txtLastName.Text = customer.LastName;
                txtDocumentNum.Text = customer.DocumentNumber.ToString();

                phones = customer.CustomerPhones
                                 .Select(cp => new PhonesWithTypeVM(cp.Phone, cp.PhoneType)) 
                                 .ToList();
                phonesList = phones.Select(pvm => pvm.Phone) 
                                   .Where(p => p != null)     
                                   .ToList()!;
                GridHelper.MostrarDatosEnGrilla<Phone>(phonesList, dgvPhones); // Pasa List<Phone>


                addresses = customer.CustomerAdresses
                              .Select(ca => new AddressWithTypeVM(ca.Address, ca.AddressType))
                              .ToList();

                // 2. Convertir la lista 'addresses' (VMs) a 'addressesList' (entidades Address) para la grilla
                addressesList = addresses.Select(avm => avm.Address) // Extrae la entidad Address de cada ViewModel
                                         .Where(a => a != null)     // Asegura que no haya nulos
                                         .ToList()!;

                // 3. Mostrar los datos en la grilla de direcciones usando 'addressesList' (List<Address>)
                GridHelper.MostrarDatosEnGrilla<Address>(addressesList, dgv); // <-- Pasa List<Address>


            }
            
            //base.OnLoad(e);

            //if (customer != null) // Modo Edición (customer ya fue establecido por SetCustomer)
            //{
            //    txtFirstName.Text = customer.FirstName;
            //    txtLastName.Text = customer.LastName;
            //    txtDocumentNum.Text = customer.DocumentNumber.ToString();
            //    // Llamar al nuevo método de servicio que trae el cliente completo
            //    // Reemplaza esto si tu SetCustomer ya carga directamente el customer con todo
            //    // customer = _customersService.GetCustomerFullDetails(customer.CustomerId); // Si customer no se carga aquí, descomenta esto

            //    // Verificar que el cliente y sus listas estén poblados
            //    if (customer != null && customer.CustomerAdresses != null && customer.CustomerPhones != null)
            //    {
            //        // Cargar las listas locales de ViewModels a partir del Customer cargado
            //        addresses = customer.CustomerAdresses
            //                        .Select(ca => new AddressWithTypeVM(ca.Address, ca.AddressType))
            //                        .ToList();
            //        phones = customer.CustomerPhones
            //                        .Select(cp => new PhonesWithTypeVM(cp.Phone, cp.PhoneType))
            //                        .ToList();

            //        // Mostrar los datos en las grillas usando las listas de ViewModels
            //        GridHelper.MostrarDatosEnGrilla<AddressWithTypeVM>(addresses, dgv);
            //        GridHelper.MostrarDatosEnGrilla<PhonesWithTypeVM>(phones, dgvPhones);
            //    }
            //    else
            //    {
            //        // Esto podría ocurrir si GetCustomerFullDetails devuelve null o las listas son null
            //        MessageBox.Show("No se pudieron cargar los detalles del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        // Puedes limpiar las grillas si quieres:
            //        // addresses.Clear(); phones.Clear(); GridHelper.LimpiarGrilla(dgv); GridHelper.LimpiarGrilla(dgvPhones);
            //    }
            //}
            //else // Modo "Agregar nuevo cliente"
            //{
            //    customer = new Customer(); // Inicializa el cliente vacío
            //    customer.CustomerAdresses = new List<CustomerAddress>();
            //    customer.CustomerPhones = new List<CustomerPhone>();
            //    addresses = new List<AddressWithTypeVM>(); // Asegúrate de que estas listas también se inicialicen
            //    phones = new List<PhonesWithTypeVM>();
            //}
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            frmAddressesAE frm = new frmAddressesAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;

            AddressWithTypeVM? addressWithType = frm.GetAddress();
            if (addressWithType is null) return;
            // Verifica si la dirección ya existe en la lista
            if (addresses.Any(dt => dt.Address
                .Equals(addressWithType?.Address)))
            {
                MessageBox.Show("La dirección ya existe en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            addresses.Add(addressWithType);
            var r = GridHelper.ConstruirFila(dgv);
            GridHelper.SetearFila(r, addressWithType.Address);
            GridHelper.AgregarFila(r, dgv);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!Regex.IsMatch(txtDocumentNum.Text, @"^\d{8}$"))
            {
                valido = false;
                errorProvider1.SetError(txtDocumentNum, "Documento debe tener exactamente 8 caracteres numéricos.");
            }
            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtLastName, "Apellido es requerido");
            }
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtFirstName, "Nombre es requerido");
            }
            if (addresses.Count == 0)
            {
                valido = false;
                errorProvider1.SetError(lblAddresses,
                    "Debe ingresar al menos una dirección");
            }

            return valido;
        }

        private void btnDeleteAddress_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            var r = dgv.SelectedRows[0];
            if (r is null) return;

            AddressWithTypeVM? addressWithTypeVM = (AddressWithTypeVM?)r.Tag;
            if (addressWithTypeVM is null) return;

            DialogResult dr = MessageBox.Show("¿Desea borrar la dirección?",
                "Confirmar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;

            addresses.Remove(addressWithTypeVM);
            GridHelper.QuitarFila(r, dgv);
        }

        public Customer? GetCustomer()
        {
            // ... (Asignaciones de campos principales) ...

            // Convertir List<PhonesWithTypeVM> a List<CustomerPhone> para guardar
            // Esto es crucial porque el servicio espera CustomerPhone
            customer.CustomerPhones = phones.Select(vm => new CustomerPhone
            {
                CustomerId = customer.CustomerId, // Asigna el CustomerId del cliente
                PhoneId = vm.Phone?.PhoneId ?? 0, // ID del Phone
                PhoneTypeId = vm.PhoneType?.PhoneTypeId ?? 0, // ID del PhoneType (¡no se perderá!)
                Phone = vm.Phone, // Objeto Phone completo (con su PhoneType dentro)
                PhoneType = vm.PhoneType // Objeto PhoneType completo
            }).ToList();

            // ... (Asignaciones para direcciones - similar si usas AddressWithTypeVM en 'addresses') ...

            return customer;
        }
        //private void btnAddPhone_Click(object sender, EventArgs e)
        //{
        //    frmPhonesAE frm = new frmPhonesAE(_serviceProvider);
        //    DialogResult dr = frm.ShowDialog(this);
        //    if (dr == DialogResult.Cancel) return;

        //    Phone? newPhoneEntity = frm.GetPhone(); // <-- ¡Aquí obtienes la entidad Phone pura!
        //    if (newPhoneEntity is null) return;

        //    // *** CONVERTIR Phone (entidad) a PhonesWithTypeVM (ViewModel) ***
        //    // Si la entidad Phone ahora tiene la propiedad PhoneType (como acordamos), esto funciona.
        //    PhonesWithTypeVM phonesWithType = new PhonesWithTypeVM(newPhoneEntity, newPhoneEntity.PhoneType);

        //    // Verifica si ya existe en la lista PRINCIPAL (List<PhonesWithTypeVM>)
        //    if (phones.Any(dt => dt.Phone?.Equals(phonesWithType.Phone) ?? false))
        //    {
        //        MessageBox.Show("Teléfono ya existe en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    phones.Add(phonesWithType); // Añade el ViewModel a la lista de ViewModels

        //    // Refrescar la grilla (MostrarDatosEnGrilla ahora ya sabe que item es un VM)
        //    GridHelper.MostrarDatosEnGrilla<PhonesWithTypeVM>(phones, dgvPhones);

        //}

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            frmPhonesAE frm = new frmPhonesAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;

            // ¡CAMBIO CLAVE AQUÍ! Llamar a GetPhone() que devuelve la entidad Phone.
            Phone? newPhoneEntity = frm.GetPhone(); // <-- ¡Ahora obtienes la entidad Phone pura!
            if (newPhoneEntity is null) return;

            // *** CONVERTIR Phone (entidad) a PhonesWithTypeVM (ViewModel) ***
            // Esto es necesario porque tu lista 'phones' es List<PhonesWithTypeVM>.
            PhonesWithTypeVM phonesWithType = new PhonesWithTypeVM(newPhoneEntity, newPhoneEntity.PhoneType);

            // Verifica si ya existe en la lista PRINCIPAL (List<PhonesWithTypeVM>)
            if (phones.Any(dt => dt.Phone?.Equals(phonesWithType.Phone) ?? false))
            {
                MessageBox.Show("Teléfono ya existe en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            phones.Add(phonesWithType); // Añade el ViewModel a la lista de ViewModels

            // GridHelper.SetearFila(r, phonesWithType.Phone); // Esto sigue bien, pasa la entidad Phone
            var r = GridHelper.ConstruirFila(dgvPhones);
            GridHelper.SetearFila(r, phonesWithType.Phone); // <--- Esto pasa la ENTIDAD Phone pura
            GridHelper.AgregarFila(r, dgvPhones);
            //frmPhonesAE frm = new frmPhonesAE(_serviceProvider);
            //DialogResult dr = frm.ShowDialog(this);
            //if (dr == DialogResult.Cancel) return;

            //PhonesWithTypeVM? phonesWithType = frm.GetPhone1();
            //if (phonesWithType is null) return;
            //// Verifica si la dirección ya existe en la lista
            //if (phones.Any(dt => dt.Phone
            //    .Equals(phonesWithType?.Phone)))
            //{
            //    MessageBox.Show("Teléfono ya existe en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //phones.Add(phonesWithType);
            //var r = GridHelper.ConstruirFila(dgvPhones);
            //GridHelper.SetearFila(r, phonesWithType.Phone);
            //GridHelper.AgregarFila(r, dgvPhones);
        }

        internal void SetCustomer(Customer customer)
        {
            this.customer = customer;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos()) // Primero, validamos todos los datos del formulario
            {
                // 1. Obtener el objeto 'customer' con todos los datos actualizados del formulario y las grillas.
                // El método GetCustomer() ya se encarga de llenar customer.Addresses y customer.Phones.
                // customer (el campo de la clase) es el objeto que estamos editando.
                Customer? customerToSave = GetCustomer(); // Asegúrate de que GetCustomer() devuelva el objeto actualizado.

                if (customerToSave is null)
                {
                    MessageBox.Show("Error: No se pudo preparar los datos del cliente para guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Llamar al servicio para guardar el cliente completo.
                try
                {
                    _customersService.SaveCustomerFullDetails(customerToSave); // <-- ¡Llamada al servicio!
                    DialogResult = DialogResult.OK; // Si todo salió bien, cerrar el formulario con OK
                }
                catch (Exception ex)
                {
                    // Manejar errores de guardado (ej. problemas de base de datos, validaciones de negocio en servicio)
                    MessageBox.Show($"Error al guardar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // No establecemos DialogResult.OK si hay error, el formulario se mantiene abierto.
                }
            }
            // else: Si ValidarDatos() falla, los errores se muestran en el formulario y este permanece abierto.
        }
        //private void btnOk_Click_1(object sender, EventArgs e)
        //{
        //    if (ValidarDatos())
        //    {
        //        if (customer is null)
        //        {
        //            customer = new Customer();
        //        }
        //        customer.DocumentNumber = int.Parse(txtDocumentNum.Text);
        //        customer.LastName = txtLastName.Text;
        //        customer.FirstName = txtFirstName.Text;
        //        customer.CustomerAdresses = addresses.Select(dt => new CustomerAddress
        //        {
        //            AddressTypeId = dt.AddressType?.AddressTypeId ?? 0,
        //            Address = dt.Address,
        //            AddressType = dt.AddressType
        //        }).ToList();
        //        customer.CustomerPhones = phones.Select(dt => new CustomerPhone
        //        {
        //            PhoneTypeId = dt.PhoneType?.PhoneTypeId ?? 0,
        //            Phone = dt.Phone,
        //            PhoneType = dt.PhoneType
        //        }).ToList();
        //        DialogResult = DialogResult.OK;
        //    }
        //}

        private void frmCustomersAE_Load(object sender, EventArgs e)
        {

        }

        private void btnEditPhones_Click(object sender, EventArgs e)
        {
            if (dgvPhones.SelectedRows.Count == 0) return;
            var r = dgvPhones.SelectedRows[0];

            // El Tag ahora guarda la entidad Phone pura (como Phone?)
            Phone? phoneToEditEntity = (Phone?)r.Tag;
            if (phoneToEditEntity is null)
            {
                MessageBox.Show("No se pudo obtener el teléfono seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cargar el objeto Phone completo y más reciente desde el servicio
            Phone? latestPhoneEntity = null;
            try { latestPhoneEntity = _customersService.GetPhoneDetails(phoneToEditEntity.PhoneId); }
            catch (Exception ex) { MessageBox.Show($"Error al cargar los detalles del teléfono: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (latestPhoneEntity is null) { MessageBox.Show("Teléfono no encontrado en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            frmPhonesAE frm = new frmPhonesAE(_serviceProvider);
            frm.SetPhone(latestPhoneEntity); // Pasamos la entidad Phone completa
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;

            Phone? updatedPhoneEntity = frm.GetPhone(); // <-- Aquí obtienes la entidad Phone pura actualizada
            if (updatedPhoneEntity is null) { MessageBox.Show("No se pudo obtener el teléfono actualizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // Encontrar el ViewModel original en la lista 'phones' (List<PhonesWithTypeVM>)
            // para actualizarlo con la entidad Phone pura que regresó.
            PhonesWithTypeVM? originalVmInList = phones.FirstOrDefault(pvm => pvm.Phone?.PhoneId == phoneToEditEntity.PhoneId);

            if (originalVmInList != null)
            {
                // Actualiza las propiedades Phone y PhoneType del ViewModel existente con la nueva entidad
                originalVmInList.Phone = updatedPhoneEntity;
                originalVmInList.PhoneType = updatedPhoneEntity.PhoneType;
            }
            else
            {
                MessageBox.Show("Error: El teléfono original no fue encontrado para actualizar en la lista principal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GridHelper.MostrarDatosEnGrilla<PhonesWithTypeVM>(phones, dgvPhones); // Refresca la grilla con List<PhonesWithTypeVM>
            MessageBox.Show("Teléfono actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDeletePhone_Click(object sender, EventArgs e)
        {
            if (dgvPhones.SelectedRows.Count == 0) return;
            var r = dgvPhones.SelectedRows[0];
            // El Tag guarda la entidad Phone pura
            Phone? phoneToDelete = (Phone?)r.Tag;
            if (phoneToDelete is null) return;

            DialogResult dr = MessageBox.Show("¿Desea borrar el teléfono?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;

            // Encontrar y eliminar el ViewModel correspondiente de la lista PRINCIPAL
            PhonesWithTypeVM? vmToDelete = phones.FirstOrDefault(pvm => pvm.Phone?.PhoneId == phoneToDelete.PhoneId);
            if (vmToDelete != null)
            {
                phones.Remove(vmToDelete); // Eliminar de la lista de ViewModels
            }

            // Sincronizar 'phonesList' (List<Phone>) para la visualización
            phonesList = phones.Select(pvm => pvm.Phone).Where(p => p != null).ToList()!;

            GridHelper.MostrarDatosEnGrilla<Phone>(phonesList, dgvPhones); // Refrescar grilla con 'phonesList'
            MessageBox.Show("Teléfono eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditAddresses_Click(object sender, EventArgs e)
        {

        }
    }
}
