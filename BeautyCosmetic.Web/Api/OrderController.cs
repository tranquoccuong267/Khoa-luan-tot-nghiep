using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BeautyCosmetic.Model.Models;
using BeautyCosmetic.Service;
using BeautyCosmetic.Web.Infrastructure.Core;
using BeautyCosmetic.Web.Models;
using BeautyCosmetic.Web.Infrastructure.Extensions;
using System.Web.Script.Serialization;
using System.Data.Entity.Validation;

namespace BeautyCosmetic.Web.Api
{
    [RoutePrefix("api/orderdetail")]
    //[Authorize]
    public class OrderController: ApiControllerBase
    {
        #region Initialize
        private IOrderService _orderDetailService;

        public OrderController(IErrorService errorService, IOrderService orderDetailService)
            : base(errorService)
        {
            this._orderDetailService = orderDetailService;
        }

        #endregion

        //[Route("getallparents")]
        //[HttpGet]
        //public HttpResponseMessage GetAll(HttpRequestMessage request)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = _orderDetailService.GetAll();

        //        var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);

        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);
        //        return response;
        //    });
        //}
        //[Route("getbyid/{id:int}")]
        //[HttpGet]
        //public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = _orderDetailService.GetById(id);

        //        var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);

        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);

        //        return response;
        //    });
        //}

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _orderDetailService.GetAll(keyword);

              

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);


                var responseData = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(query.AsEnumerable());

                var paginationSet = new PaginationSet<OrderViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }



        [Route("updatebyid/{id:int}")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage UpdateById(HttpRequestMessage request, OrderViewModel orderViewModel, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var model = _orderDetailService.GetById(id);
                    _orderDetailService.UpdatePayStatus(id);
                    _orderDetailService.Save();

                    var responseData = Mapper.Map<Order, OrderViewModel>(model);

                    response = request.CreateResponse(HttpStatusCode.OK, responseData);

                }
                return response;
            });
        }



        //[Route("deletemulti")]
        //[HttpDelete]
        //[AllowAnonymous]
        //public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProductCategories)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);
        //            foreach (var item in listProductCategory)
        //            {
        //                var model = _orderDetailService.GetById(item);
        //                model.Status = false;
        //                _orderDetailService.Update(model);
        //            }

        //            _orderDetailService.Save();

        //            response = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
        //        }

        //        return response;
        //    });
        //}
    }
}