using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProjMaster.Models
{
    public class Pedido
    {
        [BindNever]
        public int PedidoId  { get; set; }
        public List<PedidoDetalhe> PedidoItens { get; set; }

        [Required(ErrorMessage ="Informe o Nome")]
        [Display(Name ="Nome")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Informe o sobrenome")]
        [Display(Name ="Sobrenome")]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage ="Informe o endereco")]
        [Display(Name ="Endereço")]
        [StringLength(100)]
        public string Endereco1 { get; set; }

        [Required(ErrorMessage ="Informe o complemento do endereço")]
        [Display(Name ="Complemento")]
        [StringLength(100)]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage ="Informe o seu CEP")]
        [Display(Name ="CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string Cep { get; set; }

        [StringLength(20)]
        public string Estado { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage ="Informe o seu telefone")]
        [Display(Name ="Telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage ="Informe o seu email.")]
        [Display(Name ="Email")]
        [StringLength(80)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal PedidoTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime PedidoEnviado { get; set; }
        
    }
}