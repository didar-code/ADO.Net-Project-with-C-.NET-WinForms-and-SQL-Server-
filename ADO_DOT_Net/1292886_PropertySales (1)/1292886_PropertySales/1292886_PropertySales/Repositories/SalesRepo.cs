using _1292886_PropertySales.DAL;
using _1292886_PropertySales.Entities;
using System.Data;

namespace _1292886_PropertySales.Repositories
{
    public class SalesRepo
    {
        SalesGateWay dal = new SalesGateWay();

        public DataTable GetAllPaymentMethods()
        {
            DataTable dt = new DataTable();
            dt = dal.GetAllPaymentMethods();
            return dt;
        }

        public DataTable GetAllSales()
        {
            DataTable dt = new DataTable();
            dt = dal.GetAllSales();
            return dt;
        }

        public int SaveSale(Sales s)
        {
            return dal.SaveSale(s); // SalesId
        }

        public int UpdateSale(Sales s)
        {
            int updateCount = dal.UpdateSale(s);
            return updateCount;
        }

        public DataTable GetSalesById(int salesId)
        {
            DataTable dt = new DataTable();
            dt = dal.GetSalesById(salesId);
            return dt;
        }

        public int DeleteSale(int salesId)
        {
            int delete = dal.DeleteSale(salesId);
            return delete;
        }

        public int SaveProperty(Property p)
        {
            int saveCount = dal.SaveProperty(p);
            return saveCount;
        }

        public DataTable GetPropertiesBySalesId(int salesId)
        {
            DataTable dt = new DataTable();
            dt = dal.GetPropertiesBySalesId(salesId);
            return dt;
        }

        public int DeletePropertiesBySalesId(int salesId)
        {
            int delete = dal.DeletePropertiesBySalesId(salesId);
            return delete;
        }

        public DataTable GetAllSalesInfo()
        {
            DataTable dt = new DataTable();
            dt = dal.GetAllSalesInfo();
            return dt;
        }

        public DataTable GetAllProperties()
        {
            DataTable dt = new DataTable();
            dt = dal.GetAllProperties();
            return dt;
        }
        public int DeleteProperty(int propertyId)
        {
            int delete = dal.DeleteProperty(propertyId);
            return delete;
        }

        public int UpdateProperty(Property p)
        {
            int update = dal.UpdateProperty(p);
            return update;
        }
    }
}
