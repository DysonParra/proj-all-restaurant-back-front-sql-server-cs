/*
 * @fileoverview    {Chef}
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
 * TODO: Definición de {@code Chef}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Chef {

        [Key]
        public Int64? IntChefId { get; set; }
        public String? StrChefName { get; set; }
        public Single? FltSalary { get; set; }

    }

}