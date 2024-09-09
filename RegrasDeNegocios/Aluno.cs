using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProjetoEscola.RegrasDeNegocios
{
    public class Aluno
    {
        public int Id { get; set; }
        public int NumeroMatricula { get; set; }
        public string Nome { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }

        public double CalcularMedia()
        {
            return (Nota1 + Nota2) / 2;

        }
        public string VerificarSituacao()
        {
            var situacao = "REPROVADO(A)";
            if (CalcularMedia() >= 60) { situacao = "APROVADO"; }
            return situacao;
        }
        
       
    }
}
