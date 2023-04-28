
const PageItemsUri = 'api/PageItems';

function getPageItems() {
    // JS функція, за допомогою якої можна подати запит на сторінку "uri"
    fetch(PageItemsUri) // по замовченю викликаю метод GET без параметрів, тож на виході отримую набір юзерів
        .then(response => response.json()) // перетворюю дані в об'єкт JS
        .then(data => _displayItems(data)) // відправляю той об'єк в функцію _displayUsers
        .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data) {

    // для кожного юзера з набору data виводжу відповідну інформацію та додаю кнопочки
    if (Array.isArray(data)) {
        // створюю елементи та додаю атрібути
        const parentElement = document.querySelector('#indexBody');
        data.forEach(item => {
            let element = document.createElement(`${item.name}`);
            if (item.text != null)
                element.textContent = item.text;
            if (item.value != null)
                element.value = item.value;
            for (let attr of item.attributes) {
                element.setAttribute(`${attr.firstWord}`, `${attr.secondWord}`);
            }
            for (let listener of item.eventListeners) {
                element.addEventListener(`${listener.firstWord}`, listener.secondWord);
            }
            parentElement.appendChild(element);
        });
        // змінюю батьків у елементів
        data.forEach(item => {
            if (item.parent != null) {
                let element = document.getElementById(`${item.attributes.find(p => p.firstWord === 'id')?.secondWord}`);
                let elementParent = document.getElementById(`${item.parent.attributes.find(p => p.firstWord === 'id')?.secondWord}`);

                if (item.insertBeforeId == null)
                    elementParent.appendChild(element);
                else
                    elementParent.insertBefore(element, document.getElementById(`${item.insertBeforeId}`));
            }
            else {
                let element = document.getElementById(`${item.cssClass}`);
                if (item.insertBeforeId == null)
                    parentElement.appendChild(element);
                else
                    parentElement.insertBefore(element, document.getElementById(`${item.insertBeforeId}`));
            }

        });
    }
    items = data;
}