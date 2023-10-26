/*
 * @fileoverview    {Provider}
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
 * TODO: Definición de {@code Provider}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Provider {

        [Key]
        public Int64? IntProviderId { get; set; }
        public Int64? IntIngredientId { get; set; }
        public Int64? IntSupplierId { get; set; }

    }

}