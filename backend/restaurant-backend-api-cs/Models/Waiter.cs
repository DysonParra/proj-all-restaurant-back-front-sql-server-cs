/*
 * @fileoverview    {Waiter}
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
 * TODO: Definición de {@code Waiter}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Waiter {

        [Key]
        public Int64? IntWaiterId { get; set; }
        public String? StrWaiterName { get; set; }
        public Single? FltSalary { get; set; }
        public Int32? IntPhone { get; set; }

    }

}