<script>
    import Card from "./Card.svelte";
    import Player from "./Player.svelte";
    import Chat from "./Chat.svelte";
    import Battlefield from "./Battlefield.svelte";
    import Timer from "./Timer.svelte";
    import Info from "./Info.svelte"
    import { onMount } from 'svelte';
    import {roomCode, HUB} from './signalr';
    import { navigateTo } from "svelte-router-spa";
    import * as signalR from "@microsoft/signalr";

    let cards=[];
       onMount(() => {
           $HUB.invoke('PlayInit', $roomCode);
       })

       $HUB.on("clientInit", function (data) {
         console.log("clieninit");
         cards=data;
         console.log(data);
         
    });
    
</script>

<main>
    <header>
        <Player nomarg="1" />
        <Player />
        <Player />
        <Player />
    </header>
    <aside>
        <Chat />
    </aside>
    <section>
        <Battlefield />
    </section>
    <div>
        <Timer/>
        <Info/>
    </div>
    <footer>
        {#each cards as card, i}
           {#if i == 0}
           <Card nomarg="1" xp={card.points} type={card.type} />
           {:else}
           <Card xp={card.points} type={card.type} />
           {/if}
        {/each}
    </footer>
</main>

<style>
    main {
        height: 100%;
        width: 100%;
        margin: 0%;
        background-color: #2c2f33;
        position: fixed;
    }
    header {
        text-align: center;
        width: max-content;
        margin-left: 50%;
        transform: translateX(-50%);
    }
    footer {
        width: max-content;
        left: 50%;
        transform: translateX(-50%);
        position: fixed;
        bottom: 1em;
    }
    aside {
        display: inline-block;
    }
    section {
        display: inline-block;
        margin-top: 4em;
        position: absolute;
        left: 50%;
        transform: translate(-50%, 0);
    }
    div{
        float: right;
        margin-right: 1em;
        margin-top: -10%;
    }
</style>
