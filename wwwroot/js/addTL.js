const tlUri = 'api/TemplateLists';
let templateLists = [];

function getTLs() {
    fetch(tlUri)
        .then(response => response.json())
        .then(data => _displayTLs(data))
        .catch(error => console.error('Unable to get template lists.', error));
}

async function getUserId(userData) {
    const userIndexUrl = `api/Users/${userData}`;
    try {
        const response = await fetch(userIndexUrl);
        if (response.ok) {
            const data = await response.json();
            return data;
        }
        throw new Error('Failed to fetch data');
    } catch (error) {
        console.error('Unable to get user data.', error);
        throw error;
    }
}

function getTLData() {
    const addNameTextbox = document.getElementById('TL-add-name');
    const addDescriptionTextbox = document.getElementById('TL-add-description');
    const addUserTextbox = document.getElementById('TL-add-select-user');
    getUserId(addUserTextbox.value).then(udata => {

        addTL(addNameTextbox.value.trim(), addDescriptionTextbox.value.trim(), udata);

    }).catch(error => { error => console.error('Unable to get themeId.', error) });
}

function addTL(_name, _description, _userId) {
    // формую нового user як JS об'єкт покладаючись на отриману інфу
    const templateList = {
        id: 0,
        name: _name,
        description: _description,
        userId: _userId,
        user: null,
        templates: null
    };
    // перевірка. виводжу отриманого user в консоль

    console.info(JSON.stringify(templateList));
    // найвеселіше - відправляю HTTP запит до uri (так як нам потрібно POST, то вказуємо допоміжні параметри)
    fetch(tlUri, {
        method: 'POST', // вказуємо метод
        headers: {
            'Accept': 'application/json', // так як дані можна отримувати в різних форматах, то вказуємо, що запрошені дані повинні бути у форматі json
            'Content-Type': 'application/json' // так як дані можна відправляти в різних форматах, то вказуємо, що ми відправляємо саме json, щоб сервер правильно все опрацював
        },
        body: JSON.stringify(templateList) // відправляємо на сервер JS об'єкт user серіалізований у json 
    })
        .then(() => { // чистимо параметри
            getTLs();
        })
        .catch(error => console.error('Unable to add template list.', error));
}

function deleteTL(id) {
    fetch(`${tlUri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getTLs())
        .catch(error => console.error('Unable to delete user.', error));
}

function displayTLEditForm(id) {
    const tl = templateLists.find(tl => tl.id == id);

    document.getElementById('TL-edit-name').value = tl.name;
    document.getElementById('TL-edit-description').value = tl.description;
    document.getElementById('TL-edit-user').value = tl.user.name;
    document.getElementById('TL-edit-user-id').value = tl.userId;
    document.getElementById('TL-edit-tl-id').value = tl.id;

    document.getElementById('TL-edit-div').style.display = 'block';


}

function updateTL() {
    const tlId = document.getElementById('TL-edit-tl-id').value;
    const _userId = document.getElementById('TL-edit-user-id').value;
    const tlName = document.getElementById('TL-edit-name').value;
    const tlDescr = document.getElementById('TL-edit-description').value;

    const templateList = {
        id: tlId,
        name: tlName,
        description: tlDescr,
        userId: _userId,
        user: null,
        templates: null // ПОМІНЯТИ ПРИ ПОЯВІ Template
    };

    console.info(JSON.stringify(templateList));
    // відпаравляю HTTP запит з параметром PUT щоб змінити відповідного user
    fetch(`${tlUri}/${tlId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(templateList)
    })
        .then(() => getTLs())
        .catch(error => console.error('Unable to update user.', error));

    closeInput();

    return false;

    /*getLanguageId(language).then(ldata => {
        getThemeId(theme).then(tdata => {
            const user = {
                id: parseInt(userId, 10),
                name: document.getElementById('user-edit-name').value.trim(),
                personalizationId: parseInt(persId, 10),
                templateLists: null,
                personalization: {
                    id: parseInt(persId, 10),
                    themeId: parseInt(tdata, 10),
                    theme: null,
                    languageId: parseInt(ldata, 10),
                    language: null,
                    notifications: notif,
                }
            };
            console.info(JSON.stringify(user));
            // відпаравляю HTTP запит з параметром PUT щоб змінити відповідного user
            fetch(`${usersUri}/${userId}`, {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            })
                .then(() => getUsers()) // оноклюю таблицю з users 
                .catch(error => console.error('Unable to update user.', error));

            closeInput();

            return false;

        }).catch(error => { error => console.error('Unable to get themeId.', error) });

    }).catch(error => { error => console.error('Unable to get languageId.', error) });*/


}

function closeTLEdit() {
    document.getElementById('TL-edit-div').style.display = 'none';
}

function _displayTLs(data) {

    const tBody = document.getElementById('TL-show-table-TLs');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    if (Array.isArray(data)) {
        data.forEach(tl => {
            let editButton = button.cloneNode(false);
            editButton.innerText = 'Edit';
            editButton.setAttribute('onclick', `displayTLEditForm(${tl.id})`);

            let deleteButton = button.cloneNode(false);
            deleteButton.innerText = 'Delete';
            deleteButton.setAttribute('onclick', `deleteTL(${tl.id})`);


            let tr = tBody.insertRow();


            let td1 = tr.insertCell(0);
            let textNode = document.createTextNode(tl.name);
            td1.appendChild(textNode);

            let td2 = tr.insertCell(1);
            let textNodeDesc = document.createTextNode(tl.description);
            td2.appendChild(textNodeDesc);

            let td3 = tr.insertCell(2);
            let selectNodeTemplates = document.createElement('select');
            tl.templates.forEach(template => {
                let option = document.createElement('option');
                option.value = template.name;
                option.text = template.name;
                selectNodeTemplates.appendChild(option);

            })
            td3.appendChild(selectNodeTemplates);



            let td4 = tr.insertCell(3);
            td4.appendChild(editButton);

            let td5 = tr.insertCell(4);
            td5.appendChild(deleteButton);
        });
    }
    templateLists = data;
    getUsers();
}

function _displayTLAddUserList(data) {
    const tBody = document.getElementById('TL-add-user-list');
    tBody.innerHTML = '';

    if (Array.isArray(data)) {
        let selectNodeUsers = document.createElement('select');
        selectNodeUsers.setAttribute('id', 'TL-add-select-user');
        data.forEach(user => {

            let option = document.createElement('option');
            option.value = user.name;
            option.text = user.name;
            selectNodeUsers.appendChild(option);

        });

        tBody.appendChild(selectNodeUsers);
    }
}