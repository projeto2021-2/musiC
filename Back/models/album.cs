using System;
using System.Collections.Generic;



namespace musiC.Models{

    public class Album{
        public int Id { get; set; }
        public string nome { get; set; }
        public List<Musica> musicas { get; set; }
        public Artista artista { get; set; }
        public DateTime criadoEm { get; set; }
    }
}