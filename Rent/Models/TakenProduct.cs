using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent.Models
{
    public class TakenProduct
    {
        public int Id { get; set; }
        public DateTime? DateTaken { get; set; }
        public DateTime? DateReturn { get; set; }
        public bool IsDeleted { get; set; }
        public bool LessorProof { get; set; }
        public bool TenantProof { get; set; }
        public bool LessonReturnProof { get; set; }
        public decimal Cost { get; set; }
        public string PhotoProduct { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}