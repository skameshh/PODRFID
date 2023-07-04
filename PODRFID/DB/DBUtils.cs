using MySql.Data.MySqlClient;
using PODRFID.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PODRFID.DB
{
    class DBUtils
    {

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        static string delete_inv_sql = "delete from t_inventory where str_date=@str_date" ;
        public static bool doClearTodayInventory(string todaye)
        {                       
            using (MySqlConnection sqlCon = new MySqlConnection(MYGlobal.getMySqlCString()))
            {
                sqlCon.Open();

                log.Info(" doClearTodayInventory()  todaye = " + todaye);
                using (MySqlCommand cmd = new MySqlCommand(delete_inv_sql, sqlCon))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@str_date", todaye);

                    int res = cmd.ExecuteNonQuery();

                    return true;
                }
            }

                return false;
        }

        public static bool getConnectionStatus()
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(MYGlobal.getMySqlCString()))
                {
                    sqlCon.Open();
                    return true;
                }
            }
            catch (Exception ee)
            {

                log.Info("Error doUpdateUser() :" + ee.Message);

            }
           

            return false;
        }


        public static bool doAddUser(UserDao tpdao)
        {
            try
            {
                String sql = "insert into  t_user (user_id, password,  name, dept) values(@userid, @pwd, @name, @dept)";

                using (MySqlConnection sqlCon = new MySqlConnection(MYGlobal.getMySqlCString()))
                {
                    sqlCon.Open();

                    log.Info(" doUpdateUser()  userId = " + tpdao.UserId);

                    using (MySqlCommand cmd = new MySqlCommand(sql, sqlCon))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@userid", tpdao.UserId);
                        cmd.Parameters.AddWithValue("@name", tpdao.Name);
                        cmd.Parameters.AddWithValue("@pwd", tpdao.UserId);
                        cmd.Parameters.AddWithValue("@dept", tpdao.Dept);



                        int res = cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ee)
            {

                log.Info("Error doUpdateUser() :" + ee.Message);
                return false;
            }
        }



        public static bool doInsertInv(InvDao invDao)
        {
            try
            {
                String sql = "Insert into t_pod_tools (belong, type, description, Cameron_asset_no, Serial_no, " +
                    " Drive_size,Weight, Where_to_use, Calibration_date, Calibration_due_date, Status, Location, Remarks, RFID_tag) values" +
                    "(@belong, @type, @description, @Cameron_asset_no, @Serial_no, " +
                    " @Drive_size, @Weight, @Where_to_use, @Calibration_date, @Calibration_due_date, @Status, @Location, @Remarks, @RFID_tag)  ";



                using (MySqlConnection sqlCon = new MySqlConnection(MYGlobal.getMySqlCString()))
                {
                    sqlCon.Open();

                    log.Info(" doInsertInv()  ID = " + invDao.Id);

                    using (MySqlCommand cmd = new MySqlCommand(sql, sqlCon))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@belong", invDao.Belong);
                        cmd.Parameters.AddWithValue("@type", invDao.Type);
                        cmd.Parameters.AddWithValue("@description", invDao.Description);
                        cmd.Parameters.AddWithValue("@Cameron_asset_no", invDao.CameronAssetNo);
                        cmd.Parameters.AddWithValue("@Serial_no", invDao.SerialNo);
                        cmd.Parameters.AddWithValue("@Drive_size", invDao.DriveSize);
                        cmd.Parameters.AddWithValue("@Weight", invDao.Weight);
                        cmd.Parameters.AddWithValue("@Where_to_use", invDao.Where2Use);

                        if (invDao.CalibDate != null)
                        {
                            cmd.Parameters.AddWithValue("@Calibration_date", invDao.CalibDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Calibration_date", null);
                        }

                        if (invDao.CalibDueDate != null)
                        {
                            cmd.Parameters.AddWithValue("@Calibration_due_date", invDao.CalibDueDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Calibration_due_date", null);
                        }


                        cmd.Parameters.AddWithValue("@Status", invDao.Status);
                        cmd.Parameters.AddWithValue("@Location", invDao.Location);
                        cmd.Parameters.AddWithValue("@Remarks", invDao.Remarks);
                        cmd.Parameters.AddWithValue("@RFID_tag", invDao.RFIDTag);


                        int res = cmd.ExecuteNonQuery();

                        return true;
                    }

                }
            }
            catch (Exception ee)
            {

                log.Info("Error doUpdateUser() :" + ee.Message);
                return false;
            }
        }


        public static bool doUpdateInv(InvDao invDao)
        {
           
            try
            {
                String sql = "update t_pod_tools set belong=@belong, type=@type, description=@description, " +
                    " Cameron_asset_no=@Cameron_asset_no,Serial_no=@Serial_no, Drive_size=@Drive_size, Weight=@Weight, " +
                    " Where_to_use=@Where_to_use, Calibration_date=@Calibration_date, Calibration_due_date=@Calibration_due_date, " +
                    " Status=@Status, Location=@Location, Remarks=@Remarks, RFID_tag=@RFID_tag  " +
                    " where id=@id";

                using (MySqlConnection sqlCon = new MySqlConnection(MYGlobal.getMySqlCString()))
                {
                    sqlCon.Open();

                    log.Info(" doUpdateInv()  ID = " + invDao.Id);

                    using (MySqlCommand cmd = new MySqlCommand(sql, sqlCon))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@belong", invDao.Belong);
                        cmd.Parameters.AddWithValue("@type", invDao.Type);
                        cmd.Parameters.AddWithValue("@description", invDao.Description);
                        cmd.Parameters.AddWithValue("@Cameron_asset_no", invDao.CameronAssetNo);
                        cmd.Parameters.AddWithValue("@Serial_no", invDao.SerialNo);
                        cmd.Parameters.AddWithValue("@Drive_size", invDao.DriveSize);
                        cmd.Parameters.AddWithValue("@Weight", invDao.Weight);
                        cmd.Parameters.AddWithValue("@Where_to_use", invDao.Where2Use);

                        if (invDao.CalibDate != null)
                        {
                            cmd.Parameters.AddWithValue("@Calibration_date", invDao.CalibDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Calibration_date", null);
                        }

                        if (invDao.CalibDueDate != null)
                        {
                            cmd.Parameters.AddWithValue("@Calibration_due_date", invDao.CalibDueDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Calibration_due_date", null);
                        }
                       

                        cmd.Parameters.AddWithValue("@Status", invDao.Status);
                        cmd.Parameters.AddWithValue("@Location", invDao.Location);
                        cmd.Parameters.AddWithValue("@Remarks", invDao.Remarks);
                        cmd.Parameters.AddWithValue("@RFID_tag", invDao.RFIDTag);

                        cmd.Parameters.AddWithValue("@Id", invDao.Id);
                       

                        int res = cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }

            

            catch (Exception ee)
            {

                log.Info("Error doUpdateUser() :" + ee.Message);
                return false;
            }
        }

}
}
