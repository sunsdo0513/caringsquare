//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CaringSquareApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Participant
    {
        public int ParticipantId { get; set; }
        [DisplayName("User Name")]
        public string UserUserId { get; set; }
        [DisplayName("Social Event")]
        public int SocialEventEventId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual SocialEvent SocialEvent { get; set; }
    }
}
