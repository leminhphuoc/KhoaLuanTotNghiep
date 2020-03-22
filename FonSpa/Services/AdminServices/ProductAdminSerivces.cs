﻿using FonNature.Services.IServices;
using HelperLibrary;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace FonNature.Services.Services
{
    public class ProductAdminSerivces : IProductAdminSerivces
    {
        private readonly IProductAdminRepository _productAdminRepository;
        public ProductAdminSerivces(IProductAdminRepository productAdminRepository)
        {
            _productAdminRepository = productAdminRepository;
        }

        public List<Product> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _productAdminRepository.GetListProduct();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var ListProduct = _productAdminRepository.ListSearchProduct(searchString);
                return ListProduct;
            }
        }

        public List<string> GetImages(int id)
        {
            if (id == 0)
            {
                return new List<string>();
            }
            var products = _productAdminRepository.GetListProduct();
            var imageList = new List<string>();
            foreach(var product in products)
            {
                imageList.Add(product.image);
            }
            return imageList;
        }

        public List<ProductCategory> GetProductCategory()
        { 
            return _productAdminRepository.GetProductCategories();
        }
        
        public long AddProduct(Product product)
        {
            if (product == null) return 0;
            var addProduct = _productAdminRepository.AddProduct(product);
            var idProduct = addProduct;
            return idProduct;
        }

        public Product GetDetail(int id)
        {
            if (id == 0) return null;
            var product = _productAdminRepository.GetDetail(id);
            return product;
        }

        public bool Edit(Product product)
        {
            if (product == null) return false;
            var editProduct = _productAdminRepository.EditProduct(product);
            return editProduct;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _productAdminRepository.Delete(id);
            return deleteSuccess;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _productAdminRepository.ChangeStatus(id);
            return status;
        }

        public bool SaveProductImage(string images ,long id)
        {
            if (id == 0) return false;
            var serializer = new JavaScriptSerializer();
            var imagesList = serializer.Deserialize<List<string>>(images);

            var xmlElement = new XElement("ImagesList");
            foreach (var image in imagesList)
            {
                xmlElement.Add(new XElement("image", image));
            }
            var saveImageSuccess = _productAdminRepository.SaveImages(xmlElement.ToString(), id);
            return saveImageSuccess;
        }

        public List<string> GetImagesList(long id)
        {
            if (id == 0) return new List<string>();
            var imageInDb = _productAdminRepository.GetImagesList(id);
            if (imageInDb == null) return new List<string>();
            var imageXML = XElement.Parse(imageInDb);
            var imagesList = new List<string>();
            foreach (var node in imageXML.Elements())
            {
                imagesList.Add(node.Value);
            }
            return imagesList;
        }
    }
}






























































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































            