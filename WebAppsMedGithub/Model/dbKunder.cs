﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class dbKunder
    {
        [Key]
        public int Id { get; set; }
        public string Brukernavn { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public int Tlf { get; set; }
        public byte[] Passord { get; set; }
        public string Salt { get; set; }
        public virtual Poststeder Poststeder { get; set; }
    }
}
