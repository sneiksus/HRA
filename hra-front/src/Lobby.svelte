<script>
    import ConnectedUser from "./ConnectedUser.svelte";
    import { onMount } from 'svelte';
    import {roomCode, HUB} from './signalr';
    import { navigateTo } from "svelte-router-spa";
    import * as signalR from "@microsoft/signalr";
    // let hubConnection = new signalR.HubConnectionBuilder()
    //         .withUrl("https://localhost:44300/game")
    //         .build();
	// 		console.log("lobby");
    onMount(() => gpir())
    let playersInRoom=[];
    $HUB.on("roomPlayers", function (data) {
         console.log("refreshRoomData");
         playersInRoom = data;
         console.log(data[0]);
         if(playersInRoom.length>=2)
           navigateTo('play');
         
    });
    console.log('constructor '+$roomCode);
    let nick ='';


    function gpir(){
        console.log('getPlayersInRoommount '+$roomCode);
		$HUB.invoke('getPlayersInRoom', $roomCode);
    }
    function changeNick(){
        console.log('changenick '+$roomCode);
		$HUB.invoke('changeNick',  $roomCode, nick);
    }
</script>

<main>
    <div id="lobby">
        <div id="col1">
            {#each playersInRoom as item }
            <ConnectedUser nick={item.nick} isReady={item.isReady}/>
            {/each}
        </div>
        <div id="col2">
            <h3>{$roomCode}</h3>
            <p>LOBBY CODE</p>
            <input type="text" placeholder="Enter nick" bind:value={nick} id="input-code" />
            <input
                type="button"
                id="input-create"
                value="Ready"
               on:click={changeNick}
            />
        </div>
    </div>
</main>

<style>
    main {
        height: 100%;
        width: 100%;
        margin: 0%;
        background-color: #2c2f33;
        position: fixed;
    }
    #lobby {
        margin-left: 50%;
        transform: translateX(-50%);
        margin-top: 10em;
        width: 30em;
        height: 22em;
        background-color: #23272a;
        border-radius: 10px;
    }
    #col1 {
        width: 45%;
        border-right:1px solid grey;
        height: 100%;
        position: relative;
    }
    #col2 {
        width: 54%;
        height: 99%;
        transform: translateY(-100%);
        display: inline-block;
        margin-left: 45%;
    }
    h3 {
        margin-left: 50%;
        padding: 0.5em;
        border-radius: 10px;
        transform: translateX(-50%);
        width: max-content;
        border: white 2px dashed;
        font-family: "Roboto";
        font-style: normal;
        font-weight: 500;
        font-size: 1.5em;
        line-height: 28px;
        color: white;
    }
    #input-code {
        width: 50%;
        margin-top: 5em;
        margin-left: 50%;
        transform: translateX(-50%);
        height: 10%;
        background: #40454b;
        border-radius: 10px;
        color: white;
        border: none;
        font-family: "Roboto";
        font-style: normal;
        font-weight: normal;
    }
    #input-code:focus {
        outline: none;
    }
    #input-create {
        width: 45%;
        height: 12%;
        margin-left: 50%;
        transform: translateX(-50%);
        margin-top: 1em;
        background: rgb(34, 214, 28);
        border-radius: 10px;
        font-family: "Roboto";
        font-style: normal;
        font-weight: normal;
        font-size: 1em;
        color: white;
        border: none;
    }

    p{
        margin-left: 50%;
        transform: translateX(-50%);
        width: max-content;
        font-family: "Roboto";
        font-style: normal;
        font-weight: 400;
        font-size: 1.2em;
        line-height: 8px;
        color: white; 
    }
    #input-create:hover {
        background: green;
        cursor: pointer;
    }
    #input-create:active {
        background: rgb(3, 75, 3);
    }
</style>
