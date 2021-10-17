using System;

namespace WPF_IS_19_02.View
{
    internal class ControlerReceipts
    {
        internal static void Add(ModelView.ViewMaterial materrial, DB.Suppliers provider , int  count)
        {
            try
            {
                DB.Receipts receipts = new DB.Receipts();
                receipts.Id_Material = materrial.Materials.Id;
                receipts.Id_Sklad = 1;
                receipts.Id_Supplier = provider.Id;
                receipts.MaterialsCount = count;

                DB.dEntities entities = App.dEntities;
                entities.Receipts.Add(receipts);
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}