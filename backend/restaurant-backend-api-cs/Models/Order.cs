/*
 * @fileoverview    {Order}
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
 * TODO: Definición de {@code Order}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Order {

        [Key]
        public Int64? IntOrderId { get; set; }
        public Int64? IntCustomerId { get; set; }
        public Int64? IntMealId { get; set; }

    }

}