using CRUD_Navigation.Services.AddElementService;
using CRUD_Navigation.Services.DeleteElementService;
using CRUD_Navigation.Services.ListElementsService;
using CRUD_Navigation.Services.ModifyElementService;
using CRUD_Navigation.Services.SearchElementService;
using CRUD_Navigation.Services.SortListService;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Models
{
    public class CRUD
    {
        private string _name;
        private List<Element> _elements;
        private IListElements _iListElements;
        private IAddElement _iAddElements;
        private ISearchElement _iSearchElement;
        private IDeleteService _iDeleteElement;
        private IModifyElement _imodifyElement;
        private ISortService _isortList;

        public CRUD(string name,IListElements ilistElements,IAddElement iaddElement, ISearchElement iSearchElement, IDeleteService iDeleteService, IModifyElement iModifyElement, ISortService isortService)
        {
            _name = name;
            _iListElements = ilistElements;
            _iAddElements = iaddElement;
            _iSearchElement = iSearchElement;
            _iDeleteElement= iDeleteService;
            _imodifyElement = iModifyElement;
            _isortList = isortService;
        }

        public  async Task<IEnumerable<ElementWithID>> ListELements() {
            return await _iListElements.ListElements();
        }   
        public async Task Add(Element ELement) {
            await _iAddElements.AddElement(ELement);
        }

        public async Task<ElementWithID> SearchElement(int Id)
        {
            return await _iSearchElement.SearchElement(Id);
        }
        public async Task<bool> Delete(int ID) {
           return  await _iDeleteElement.DeleteElement(ID);
        }
        public async Task<bool> Modify(int ID, Element element) {
           return await _imodifyElement.ModifyElement(ID, element);
        }

        public IEnumerable<ElementWithID> SortedList(string type, IEnumerable<ElementWithID> elements) {
            return _isortList.Sortlist(type, elements);
        }

    }
}
