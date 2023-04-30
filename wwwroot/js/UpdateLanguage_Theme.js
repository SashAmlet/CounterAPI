function _displayUserAddLanguageThemeList(data, tbodyId, selectId) {
    const tBody = document.getElementById(tbodyId);
    tBody.innerHTML = '';

    if (Array.isArray(data)) {
        let selectNodeUsers = document.createElement('select');
        selectNodeUsers.setAttribute('id', selectId);
        data.forEach(language => {

            let option = document.createElement('option');
            option.value = language.name;
            option.text = language.name;
            selectNodeUsers.appendChild(option);

        });

        tBody.appendChild(selectNodeUsers);
    }
}