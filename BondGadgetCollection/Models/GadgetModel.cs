using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BondGadgetCollection.Models
{
    public class GadgetModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Описание")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Появлялся в этом фильме")]
        public string AppearsIn { get; set; }
        [Required]
        [DisplayName ("Актеры")]
        public string WithThisActor { get; set; }

        public GadgetModel()
        {
            Id = -1;
            Name = "";
            Description = "";
            AppearsIn = "";
            WithThisActor = "";
        }

        public GadgetModel(int id, string name, string description, string appearsIn, string withThisActor)
        {
            Id = id;
            Name = name;
            Description = description;
            AppearsIn = appearsIn;
            WithThisActor = withThisActor;
        }
    }
}