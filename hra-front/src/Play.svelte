<script>
    import Card from "./Card.svelte";
    import Player from "./Player.svelte";
    import Chat from "./Chat.svelte";
    import Battlefield from "./Battlefield.svelte";
    import Timer from "./Timer.svelte";
    import Info from "./Info.svelte"
    import { onMount } from 'svelte';
    import {roomCode, HUB, ID} from './signalr';
    import { navigateTo } from "svelte-router-spa";
    import * as signalR from "@microsoft/signalr";

    let players=[];
    let cards=[];
    let attack=null;
    let defend=null;
    let roomDeck=null;
    let seconds = 30;
    let yt="nil";
       onMount(() => {
           $HUB.invoke('PlayInit', $roomCode);
       })
       $HUB.on("clientInit", function (d) {
         console.log("clieninit "+$ID);
          cards=[];
          for(var i = 0;i<d.players.length;i++)
          if(d.players[i].id == $ID)
          if(d.players[i].isLoser == true)
          alert('Loser!');
          else if(d.players[i].isWiner == true)
          alert('Winner!');
         players=d.players;
         for(var i = 0;i<d.players.length;i++)
         if(d.players[i].id == $ID)
         cards=d.players[i].cards;
         roomDeck=d.roomDeck.length;
         attack=d.attack;
         defend=d.defend;
         seconds = d.counter.seconds;
         if(d.current.id == $ID)
         yt="cur";
         else if(d.next.id == $ID)
         yt="nxt";
         else
         yt="nil";
         console.log("crnt "+yt)
         console.log(d);
         
    });

    
</script>

<main>
    <header>
        {#each players as player, i}
        {#if i == 0}
        <Player nomarg="1" xp={player.xp} isMe={player.id == $ID ? true : false} nick={player.nick}/>
        {:else}
        <Player xp={player.xp} isMe={player.id == $ID ? true : false} nick={player.nick}/>
        {/if}
     {/each}
    </header>
    <aside>
        <Chat />
    </aside>
    <section>
        <Battlefield attack={attack} defend={defend}/>
    </section>
    <div>
        <Timer seconds={seconds} yt={yt}/>
        <Info roomDeck={roomDeck}/>
    </div>
    <footer>
        {#each cards as card, i}
           {#if i == 0}
           <Card nomarg="1"  xp={card.points} type={card.type} />
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
