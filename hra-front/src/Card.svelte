<script>
    import {roomCode, HUB} from './signalr';

    export let nomarg=0;
    export let xp=-1;
    export let type="n";

    let a, b;
    !nomarg ? a = 'yemarg ' : a = 'nomarg ';
    if(type == 0)
    b = " attack";
    else if(type == 1)
    b = " resources";
    else if(type == 2)
    b = " thief";
    else
    b = " sabotage";


    function moveCard(){
        console.log(type)
        $HUB.invoke("moveCard", type, xp, $roomCode);
    }
</script>

<!-- <div id="card" on:click={moveCard} class="{[a,b]}">
    {#if type == 0}
    <img src="./static/Attack.png" alt="logo"/>
    {:else if type == 1}
    <img src="./static/Resources.png" alt="logo"/>
    {:else if type == 2}
    <img src="./static/Thief.png" alt="logo"/>
    {:else if type == 3}
    <img src="./static/Sabotage.png" alt="logo"/>
    {/if}
    <h1>{type}</h1>
    <p>{xp}</p>
</div> -->


{#if type == 0}
<div id="card" on:click={moveCard} class="{a} attack">
    <img src="./static/Attack.png" alt="logo"/>
    <h1>{type}</h1>
    <p>{xp}</p>
</div>
    {:else if type == 1}
    <div id="card" on:click={moveCard} class="{a} resources">
        <img src="./static/Resources.png" alt="logo"/>
        <h1>{type}</h1>
        <p>{xp}</p>
    </div>
    {:else if type == 2}
    <div id="card" on:click={moveCard} class="{a} thief">
        <img src="./static/Thief.png" alt="logo"/>
        <h1>{type}</h1>
        <p>{xp}</p>
    </div>
    {:else if type == 3}
    <div id="card" on:click={moveCard} class="{a} sabotage">
        <img src="./static/Sabotage.png" alt="logo"/>
        <h1>{type}</h1>
        <p>{xp}</p>
    </div>
    {/if}

<style>
    div {
        background-color: #40454b;
        height: 11em;
        width: 7em;
        border: 7px solid white;
        border-radius: 15px;
        transition: transform 0.2s ease-in-out;
        display: inline-block;
        text-align: center;
    }

    .attack{
        border: 7px solid red;
    }
    .resources{
        border: 7px solid yellow;
    }
    .thief{
        border: 7px solid purple;
    }

    .sabotage{
        border: 7px solid blue;
    }


    div:hover{
        transform: translateY(-1em);
        cursor: pointer;
    }

    img {
        width: 90%;
        margin-top: 1em;
    }

    h1 {
        margin-top: 1em;
        font-family: Roboto;
        font-style: normal;
        font-weight: normal;
        font-size: 1em;
        line-height: 14px;
        color: white;
    }

    p {
        font-family: 'Roboto';
        font-style: normal;
        font-weight: 500;
        font-size: 1em;
        line-height: 14px;
        color: white;
        margin-top: 0.6em;
    }

    .nomarg{
        margin-left: 0em;
    }
    .yemarg{
        margin-left: 2em;
    }
</style>
