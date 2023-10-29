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
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Description of {@code Customer}.
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