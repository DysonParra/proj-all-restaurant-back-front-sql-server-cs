/*
 * @fileoverview    {Customer}
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
 * TODO: Definición de {@code Customer}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Customer {

        [Key]
        public Int64? IntCustomerId { get; set; }
        public String? StrCustomerName { get; set; }
        public String? StrAddress { get; set; }
        public Int32? IntPhone { get; set; }
        public Int64? IntWaiterId { get; set; }

    }

}