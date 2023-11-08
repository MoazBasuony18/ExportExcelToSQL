namespace ExportExcelToSQL.Models
{
    public class AirportDTO
    {
        public string AirportName { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifyOn { get; set; }
        public string CountryName { get; set; }
        public string THLCode { get; set; }
        public int ZoneCodeId { get; set; }
    }
}
