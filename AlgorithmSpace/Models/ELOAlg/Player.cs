using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.ELOAlg
{
    public class Player
    {
        public int Id { get; set; }
        public double Elo { get; set; }

        public Player(int id, double elo)
        {
            Id = id;
            Elo = elo;
        }
    }
}
