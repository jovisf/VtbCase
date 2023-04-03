using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VtbCase.Shared
{
    public class Segment
    {

        public int Id { get; set; }
        public required string Nome { get; set; } = String.Empty;

        public string Descricao { get; set; } = String.Empty;

    }
}