using ASP.NETCoreIdentityCustom.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ASP.NETCoreIdentityCustom.Data
{
    public class PrescriptionDataAccess
    {

        string connectionString = "Server=192.168.1.250\\SQL2019INT; Database=CMS_42; User Id=uttam; Password=uttam; Trusted_Connection=false; MultipleActiveResultSets=true";

        SqlConnection con = null;
        SqlCommand cmd = null;


        public PrescriptionDataAccess()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }

        public void AddPprescription(PrescriptionModel model)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand("AddPrescription", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", model.PID);
                cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy");
                cmd.Parameters.AddWithValue("@MedicineName", model.medicine_name);
                cmd.Parameters.AddWithValue("@SoldQuantity", model.quantity);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public List<PrescriptionModel> GetQuantity(string MedName)
        {
            List<PrescriptionModel> list = new List<PrescriptionModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                cmd = new SqlCommand("GetQuantity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@medname", SqlDbType.VarChar).Value = MedName;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    PrescriptionModel PM = new PrescriptionModel();
                    PM.quantity = Convert.ToInt32(sdr["M_Stock"]);
                    list.Add(PM);

                }
                con.Close();

            }
            return list;
        }


        public List<MedicineModel> GetMedicineDDLData(string orderby, string whereclause)
        {
            List<MedicineModel> list = new List<MedicineModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                cmd = new SqlCommand("GetMedicine", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("orderby", SqlDbType.VarChar).Value = orderby;
                cmd.Parameters.AddWithValue("whereclause", SqlDbType.VarChar).Value = whereclause;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    MedicineModel M = new MedicineModel();
                    M.M_Id = Convert.ToInt32(sdr["MID"]);
                    M.M_Name = sdr["M_Name"].ToString();
                    M.M_Stock = Convert.ToInt32(sdr["M_Stock"]);
                    list.Add(M);

                }
                con.Close();

            }
            return list;
        }
        public List<PrescriptionModel> ViewPrescription(string orderby, string whereclause)
        {
            List<PrescriptionModel> ULst = new List<PrescriptionModel>();
            using (con)
            {
                SqlCommand cmd = new SqlCommand("ViewPrescription", con);
                cmd.Parameters.AddWithValue("@orderby", SqlDbType.VarChar).Value = orderby;
                cmd.Parameters.AddWithValue("@whereclause", SqlDbType.VarChar).Value = whereclause;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PrescriptionModel U = new PrescriptionModel();
                    U.pres_id = Convert.ToInt32(rdr["pres_id"]);
                    U.P_FName = rdr["P_FName"].ToString();
                    U.P_LName = rdr["P_LName"].ToString();
                    U.CreatedAt = rdr["CreatedAt"].ToString();
                    U.PID = Convert.ToInt32(rdr["PID"]);
                    U.medicine_name = rdr["medicine_name"].ToString();
                    U.quantity = Convert.ToInt32(rdr["quantity"]);
                    ULst.Add(U);
                }
                con.Close();
            }
            return ULst;
        }

    }
}
