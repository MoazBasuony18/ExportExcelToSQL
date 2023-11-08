using System.ComponentModel.DataAnnotations.Schema;

namespace ExportExcelToSQL.Models
{
    [Table("Airport", Schema = "Cargo")]
    public class Airport
    {
        public int Id { get; set; }
        public string AirportName { get; set; }
        public bool IsDeleted { get; set; }=false;
        public int CreatedBy { get; set; } = 1;
        public DateTime CreatedOn { get; set; }=DateTime.Now;
        public DateTime ModifyOn { get; set; }=DateTime.Now;
        public string CountryName { get; set; }
        public string THLCode { get; set; }
        public int ZoneCodeId { get; set; } = 1;



    }
}
