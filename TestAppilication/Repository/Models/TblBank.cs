using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestAppilication.Repository.Models
{
    [Table("tblBank")]
    public partial class TblBank
    {
        [Key]
        public int BankId { get; set; }
        [StringLength(200)]
        public string BankName { get; set; }
    }
}
