﻿namespace RazorLogin.Models
{
    public class MPersonne
    {
        public int idPersonne { get; set;  }
        public string nomPersonne { get; set; }
        public string prenomPersonne { get; set; }
        public byte[] mdp { get; set; }
    }
}
