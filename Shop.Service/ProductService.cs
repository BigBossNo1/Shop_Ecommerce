﻿using Shop.Common;
using Shop.Data.Infastructure;
using Shop.Data.Repository;
using Shop.Models.Models;
using System;
using System.Collections.Generic;

namespace Shop.Service
{
    public interface IProductService
    {
        Product Add(Product Product);

        void Update(Product Product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyWord);

        IEnumerable<Product> GetListProductByCategoryIdPage(int categryID, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<string> GetListProductByName(string name);

        IEnumerable<Product> GetReatedProduct(int id, int top);

        IEnumerable<Product> GetLastest(int top);

        IEnumerable<Product> GetHotProduct(int top);

        Product GetById(int id);

        void Save();

        Tag getTag(string tagID);

        // lấy ra tag
        IEnumerable<Tag> GetListTagProductID(int id);

        // phân trang
        IEnumerable<Product> GetListProductByTag(string tagID, int page, int pageSize, out int totalRow);
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productService, ITagRepository tagRepository, IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productService;
            this._tagRepository = tagRepository;
            this._productTagRepository = productTagRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product Product)
        {
            Product.Createdate = DateTime.Now;
            var addProduct = _productRepository.Add(Product);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] arrTag = Product.Tags.Split(',');
                for (var i = 0; i < arrTag.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(arrTag[i]);
                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagID;
                        tag.Name = arrTag[i];
                        tag.Type = "Product";
                        _tagRepository.Add(tag);
                    }
                    ProductTag productTag = new ProductTag();
                    productTag.TagID = tagID;
                    productTag.ProductID = Product.ID;
                    _productTagRepository.Add(productTag);
                }
                _unitOfWork.Commit();
            }
            return addProduct;
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))
            {
                return _productRepository.GetMulti(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord));
            }
            else
            {
                return _productRepository.GetAll();
            }
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public IEnumerable<Product> GetHotProduct(int top)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetLastest(int top)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetListProductByCategoryIdPage(int categryID, int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetListProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetListProductByTag(string tagID, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetListTagProductID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetReatedProduct(int id, int top)
        {
            throw new NotImplementedException();
        }

        public Tag getTag(string tagID)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public void Update(Product Product)
        {
            _productRepository.Update(Product);
            _productTagRepository.DeleteMulti(x => x.ProductID == Product.ID);
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] arrTag = Product.Tags.Split(',');
                for (var i = 0; i < arrTag.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(arrTag[i]);
                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagID;
                        tag.Name = arrTag[i];
                        tag.Type = "Product";
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag();
                    productTag.TagID = tagID;
                    productTag.ProductID = Product.ID;
                    _productTagRepository.Add(productTag);
                }
            }
            _unitOfWork.Commit();
        }
    }
}