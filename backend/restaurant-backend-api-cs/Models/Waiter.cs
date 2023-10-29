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
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Description of {@code Waiter}.
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