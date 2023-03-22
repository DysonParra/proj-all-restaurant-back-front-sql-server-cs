/*
 * @fileoverview    {Supplier}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Definición de {@code Supplier}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Supplier {

        [Key]
        public Int64? IntSupplierId { get; set; }
        public String? StrSupplierCity { get; set; }
        public String? TxtSupplierName { get; set; }
        public Int32? IntPhone { get; set; }
        public Int64? IntChefId { get; set; }

    }

}