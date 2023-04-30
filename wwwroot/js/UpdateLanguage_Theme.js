function _displayUserAddLanguageList(data) {
    const tBody = document.getElementById('user-add-language-list');
    tBody.innerHTML = '';

    if (Array.isArray(data)) {
        let selectNodeUsers = document.createElement('select');
        selectNodeUsers.setAttribute('id', 'user-select-language');
        data.forEach(language => {

            let option = document.createElement('option');
            option.value = language.name;
            option.text = language.name;
            selectNodeUsers.appendChild(option);

        });

        tBody.appendChild(selectNodeUsers);
    }
}

function _displayUserAddThemeList(data) {
    const tBody = document.getElementById('user-add-theme-list');
    tBody.innerHTML = '';

    if (Array.isArray(data)) {
        let selectNodeUsers = document.createElement('select');
        selectNodeUsers.setAttribute('id', 'user-select-theme');
        data.forEach(language => {

            let option = document.createElement('option');
            option.value = language.name;
            option.text = language.name;
            selectNodeUsers.appendChild(option);

        });

        tBody.appendChild(selectNodeUsers);
    }
}