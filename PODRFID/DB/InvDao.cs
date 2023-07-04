using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PODRFID.DB
{
    public class InvDao
    {
        public int Id { set; get; }
        public String Belong { set; get; }
        public String Type { set; get; }
        public string Description { set; get; }
        public string CameronAssetNo { set; get; }
        public string SerialNo { set; get; }
        public string DriveSize { set; get; }
        public string Weight { set; get; }
        public string Where2Use { set; get; }
        public string Status { set; get; }
        public DateTime CalibDate { set; get; }
        public DateTime CalibDueDate { set; get; }
        public string Location { set; get; }
        public string Remarks { set; get; }
        public string RFIDTag { set; get; }
    }
}
