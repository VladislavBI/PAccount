//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PAccountant.DataLayer.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class other_SpendHoursPerProject
    {
        public int Id { get; set; }
        public double SpendHours { get; set; }
        public int ProjectId { get; set; }
    
        public virtual other_Projects other_Projects { get; set; }
    }
}
