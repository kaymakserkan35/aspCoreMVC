$(document).ready(function () {

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/MessageHub")
        .build();
    connection.start()
        .catch(err => alert(err.toString()));


    $("#btnPrivateGroup").click(function (e) {
        console.log("join button clicked!");
        connection.invoke('JoinGroup', "PrivateGroup");
        e.preventDefault();
    });



    $("#btnSend").click(function (e) {
        console.log("send button clicked!");
        let message = $('#messagebox').val();
        let sender = $('#senderUId').text();
        let group = "PrivateGroup";
        $('#messagebox').val('');

        connection.invoke('SendMessageToGroup', group, sender, message);
        e.preventDefault();
    });


    connection.on("SendMessage", function (sender, message) {
        console.log("sendmessage method executed");
        appendLine(sender, message);

    });

    function appendLine(uid, message) {
        let nameElement = document.createElement('strong');
        nameElement.innerText = `${uid}:`;
        let msgElement = document.createElement('em');
        msgElement.innerText = ` ${message}`;
        let li = document.createElement('li');
        li.appendChild(nameElement);
        li.appendChild(msgElement);
        $('#messageList').append(li);
    };


});