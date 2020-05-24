'use strict';
(function () {
    const $jwt = document.getElementById("jwt");
    const $connect = document.getElementById("connect");
    const $disconnect = document.getElementById("disconnect");
    const $messages = document.getElementById("messages");
    const connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:5007/micros')
        .configureLogging(signalR.LogLevel.Information)
        .build();
    console.dir(connection);
    $disconnect.onclick = function () {
        connection.stop();
    }
    $connect.onclick = function () {
        //alert($jwt.value);
        const jwt = $jwt.value;
        if (!jwt || jwt.trim().length == 0) {
            console.log(jwt.length)
            //alert("vide");
            connection.start()
                .then(() => {
                    connection.invoke('initializeAsync', "");
                })
                .catch(err => appendMessage(err));
            return;
        }
        if (!jwt || /\s/g.test(jwt)) {
            alert('Invalid JWT.')
            return;
        }

        appendMessage("Connecting to MicroS Hub...");
        connection.start()
            .then(() => {
                connection.invoke('initializeAsync', $jwt.value);
            })
            .catch(err => appendMessage(err));
    }

    connection.on('connected', _ => {
        appendMessage("Connected.", "primary");
        toggleButton(true);
    });

    connection.on('disconnected', _ => {
        appendMessage("Disconnected, invalid token..", "danger");
        toggleButton(false);
    });

    connection.on('operation_pending', (operation) => {
        appendMessage('Operation pending.', "light", operation);
    });

    connection.on('operation_completed', (operation) => {
        appendMessage('Operation completed.', "success", operation);
    });

    connection.on('operation_rejected', (operation) => {
        appendMessage('Operation rejected.', "danger", operation);
    });

    function toggleButton(connected) {
        $connect.style.visibility = !connected? "visible" : "hidden";
        $disconnect.style.visibility = connected ? "visible" : "hidden";
    }
    function appendMessage(message, type, data) {
        var dataInfo = "";
        if (data) {
            dataInfo += "<div>" + JSON.stringify(data) + "</div>";
        }
        $messages.innerHTML += `<li class="list-group-item list-group-item-${type}">${message} ${dataInfo}</li>`;
    }
})();