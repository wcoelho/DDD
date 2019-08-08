using System;
using Xunit;
using DDD.Infra.Data.Repository;
using DDD.Domain.Interfaces;
using DDD.Domain.Entities;
using DDD.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DDD.Service.Validators;
using FluentValidation;

namespace DDD.Tests
{
    public class CheckProduct
    {
      	[Theory]
        [InlineData("pdt1", "2", "22", 4, "teste")]
        [InlineData("pdt2", "3", "33", 1, "teste")]
        [InlineData("pdt3", "4", "44", -1, "teste")]
        public void CanCreateAndSave(string name, string codigo, string sku, double preco, string fabricante="")
        {
            TestService<Product> service = new TestService<Product>();

            var pdt = new Product();
            Assert.NotNull(pdt);
            pdt.Name = name;
            pdt.Code = codigo;
            pdt.SKU = sku;
            pdt.Price = preco;
            pdt.Manufacturer = fabricante;

            // Se houver erro em validações, deve dar erro ao adicionar no banco.
            if (preco < 0 || name.Length < 1 || sku.Length < 1 || codigo.Length < 1 ) {
                Assert.Throws<FluentValidation.ValidationException>(() => service.Post<ProductValidator>(pdt));
                return;
            }
            // Agora criando, resgatando, comparando e deletando.
            service.Post<ProductValidator>(pdt);
            Assert.True(pdt.Id > -1);
            var pdt2 = service.Get(pdt.Id);

            Assert.Equal(pdt2.Name, pdt.Name);
            Assert.Equal(pdt2.SKU, pdt.SKU);
            Assert.Equal(pdt2.Manufacturer, pdt.Fabricante);

            var id = pdt.Id;
            service.Delete(pdt.Id);

            // Tentando deletar novamente e verificando se Exception é gerada.
            Assert.Throws<System.ArgumentNullException>(() => service.Delete(id));
        }

    }
}