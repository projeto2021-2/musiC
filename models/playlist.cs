using System;
using System.Collections.Generic;

namespace musiC.Models
{
    public class Playlist{
        
        public int Id {get; set; }
        public string nome { get; set; }
        public List<Musica> musicas { get; set; }
        public Usuario usuario { get; set; }
        public DateTime criadoEm { get; set; }
    }
}