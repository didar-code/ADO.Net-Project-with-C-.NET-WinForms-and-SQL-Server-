using _1292886_PropertySales.Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _1292886_PropertySales.DAL
{
    public class SalesGateWay
    {
        
        string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public DataTable GetAllPaymentMethods()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                string query = "SELECT PaymentId, PaymentType FROM PaymentMethod";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                sqlcon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetAllSales()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
               
                string query = @"SELECT s.SalesId, s.ClientName, s.MobileNo, s.TotalPrice, s.PaymentId, pm.PaymentType,
                                        FORMAT(s.SaleDate,'yyyy-MM-dd') AS SaleDate,
                                        CASE WHEN s.IsPaid=1 THEN 'Paid' ELSE 'UnPaid' END AS Status,
                                        s.IsPaid, s.ClientImage
                                 FROM Sales s
                                 JOIN PaymentMethod pm ON s.PaymentId = pm.PaymentId
                                 ORDER BY s.SalesId DESC";

                SqlCommand cmd = new SqlCommand(query, sqlcon);
                sqlcon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetSalesById(int salesId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                string query = @"SELECT SalesId, SaleDate, TotalPrice, ClientName, MobileNo, ClientImage, PaymentId, IsPaid
                                 FROM Sales WHERE SalesId=@SalesId";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = salesId;

                sqlcon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

      
        public int SaveSale(Sales s)
        {
            int salesId = 0;

            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                sqlcon.Open();
                using (SqlTransaction tran = sqlcon.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO Sales (SaleDate, TotalPrice, ClientName, MobileNo, ClientImage, PaymentId, IsPaid)
                            VALUES (@SaleDate, @TotalPrice, @ClientName, @MobileNo, @ClientImage, @PaymentId, @IsPaid);
                            SELECT SCOPE_IDENTITY();", sqlcon, tran);

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@SaleDate", SqlDbType.DateTime).Value = s.SaleDate;
                        cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = s.TotalPrice;
                        cmd.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = s.ClientName;
                        cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = s.MobileNo;
                        cmd.Parameters.Add("@ClientImage", SqlDbType.VarChar).Value = s.ClientImage ?? "";
                        cmd.Parameters.Add("@PaymentId", SqlDbType.Int).Value = s.PaymentId;
                        cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = s.IsPaid;

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            salesId = Convert.ToInt32(result);
                        }

                        tran.Commit();
                        return salesId;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        Console.WriteLine($"Error Occured: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public int UpdateSale(Sales s)
        {
            int count = 0;
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                sqlcon.Open();
                using (SqlTransaction tran = sqlcon.BeginTransaction())
                {
                    try
                    {
                       
                        bool hasImage = !string.IsNullOrWhiteSpace(s.ClientImage);

                        string queryWithImage = @"
                    UPDATE Sales
                    SET SaleDate=@SaleDate,
                        TotalPrice=@TotalPrice,
                        ClientName=@ClientName,
                        MobileNo=@MobileNo,
                        ClientImage=@ClientImage,
                        PaymentId=@PaymentId,
                        IsPaid=@IsPaid
                    WHERE SalesId=@SalesId";

                        string queryWithoutImage = @"
                    UPDATE Sales
                    SET SaleDate=@SaleDate,
                        TotalPrice=@TotalPrice,
                        ClientName=@ClientName,
                        MobileNo=@MobileNo,
                        PaymentId=@PaymentId,
                        IsPaid=@IsPaid
                    WHERE SalesId=@SalesId";

                        using (SqlCommand cmd = new SqlCommand(hasImage ? queryWithImage : queryWithoutImage, sqlcon, tran))
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = s.SalesId;
                            cmd.Parameters.Add("@SaleDate", SqlDbType.DateTime).Value = s.SaleDate;
                            cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = s.TotalPrice;
                            cmd.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = s.ClientName;
                            cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = s.MobileNo;
                            cmd.Parameters.Add("@PaymentId", SqlDbType.Int).Value = s.PaymentId;
                            cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = s.IsPaid;

                            if (hasImage)
                            {
                                cmd.Parameters.Add("@ClientImage", SqlDbType.VarChar).Value = s.ClientImage;
                            }

                            count = cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return count;
        }


        
        public int DeleteSale(int salesId)
        {
            int count = 0;
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                sqlcon.Open();
                using (SqlTransaction tran = sqlcon.BeginTransaction())
                {
                    try
                    {
                        // child delete
                        using (SqlCommand cmdChild = new SqlCommand("DELETE FROM Property WHERE SalesId=@SalesId", sqlcon, tran))
                        {
                            cmdChild.CommandType = CommandType.Text;
                            cmdChild.Parameters.Add("@SalesId", SqlDbType.Int).Value = salesId;
                            cmdChild.ExecuteNonQuery();
                        }

                        // master delete
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Sales WHERE SalesId=@SalesId", sqlcon, tran))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = salesId;
                            count = cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return count;
                    }
                    catch
                    {
                        tran.Rollback();
                        return 0;
                    }
                }
            }
        }

        public int SaveProperty(Property p)
        {
            int count = 0;
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                sqlcon.Open();
                using (SqlTransaction tran = sqlcon.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO Property (PropertyType, Location, SalesId)
                            VALUES (@PropertyType, @Location, @SalesId)", sqlcon, tran))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@PropertyType", SqlDbType.VarChar).Value = p.PropertyType;
                            cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = p.Location;
                            cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = p.SalesId;

                            count = cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return count;
                    }
                    catch
                    {
                        tran.Rollback();
                        return 0;
                    }
                }
            }
        }


        public int UpdateProperty(Property p)
        {
            int count = 0;
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                sqlcon.Open();
                using (SqlTransaction tran = sqlcon.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                    UPDATE Property
                    SET PropertyType = @PropertyType,
                        Location = @Location
                    WHERE PropertyId = @PropertyId", sqlcon, tran))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@PropertyId", SqlDbType.Int).Value = p.PropertyId;
                            cmd.Parameters.Add("@PropertyType", SqlDbType.VarChar).Value = p.PropertyType;
                            cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = p.Location;

                            count = cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return count;
                    }
                    catch
                    {
                        tran.Rollback();
                        return 0;
                    }
                }
            }
        }

        public int DeleteProperty(int propertyId)
        {
            int count = 0;
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                sqlcon.Open();
                using (SqlTransaction tran = sqlcon.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                    DELETE FROM Property
                    WHERE PropertyId = @PropertyId", sqlcon, tran))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@PropertyId", SqlDbType.Int).Value = propertyId;

                            count = cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return count;
                    }
                    catch
                    {
                        tran.Rollback();
                        return 0;
                    }
                }
            }
        }


        public DataTable GetPropertiesBySalesId(int salesId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                string query = @"SELECT PropertyId, PropertyType, Location, SalesId
                                 FROM Property
                                 WHERE SalesId=@SalesId
                                 ORDER BY PropertyId DESC";

                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = salesId;

                sqlcon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int DeletePropertiesBySalesId(int salesId)
        {
            int count = 0;
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                sqlcon.Open();
                using (SqlTransaction tran = sqlcon.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Property WHERE SalesId=@SalesId", sqlcon, tran))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = salesId;
                            count = cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return count;
                    }
                    catch
                    {
                        tran.Rollback();
                        return 0;
                    }
                }
            }
        }

        //public DataTable GetAllSalesInfo()
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection sqlcon = new SqlConnection(conStr))
        //    {
        //        string query = @"
        //            SELECT 
        //                s.SalesId, s.ClientName, s.MobileNo, s.TotalPrice,
        //                FORMAT(s.SaleDate,'yyyy-MM-dd') AS SaleDate,
        //                s.ClientImage, s.IsPaid,
        //                pm.PaymentId, pm.PaymentType,
        //                p.PropertyId, p.PropertyType, p.Location
        //            FROM Sales s
        //            INNER JOIN PaymentMethod pm ON s.PaymentId = pm.PaymentId
        //            LEFT JOIN Property p ON s.SalesId = p.SalesId
        //            ORDER BY s.SalesId DESC";

        //        SqlCommand cmd = new SqlCommand(query, sqlcon);
        //        sqlcon.Open();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //    }
        //    return dt;
        //}
        public DataTable GetAllSalesInfo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                string query = @"
                    SELECT 
                        s.SalesId, s.ClientName, s.MobileNo, s.TotalPrice,
                        FORMAT(s.SaleDate,'yyyy-MM-dd') AS SaleDate,
                        s.ClientImage, s.IsPaid,
                        pm.PaymentId, pm.PaymentType
                        
                    FROM Sales s
                    INNER JOIN PaymentMethod pm ON s.PaymentId = pm.PaymentId
                    ";

                SqlCommand cmd = new SqlCommand(query, sqlcon);
                sqlcon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetAllProperties()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                string query = "SELECT * FROM Property";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                sqlcon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            return dt;
        }
    }
}
