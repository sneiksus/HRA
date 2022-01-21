<script>
    export let nick;
    export let isReady=false;
</script>

<div id="root">
    <div id="box">
        <img src="./static/ava.png" alt="ava" />
    </div>  
    <h3>{nick}</h3>
    {#if isReady == true}
    <p>ready</p>
    {/if}
</div>

<style>
    #root {
        width: 92%;
        padding: 0.5em;
        padding-left: 1em;
        padding-top: 1em;
    }
    #box {
        outline: 2px solid blue;
        border-radius: 10px;
        width: max-content;
        padding: 0.5em;
        height: max-content;
        display: inline-block;
    }
    img {
        width: 2.2em;
        height: 2.2em;
        margin-left: 50%;
        transform: translateX(-50%);
        margin-top: 0.1em;
    }
    h3 {
        display: inline-block;
        color: white;
        font-family: "Roboto";
        font-style: normal;
        font-weight: 600;
        font-size: 18px;
        line-height: 14px;
        margin-left: 0.5em;
        transform: translateY(-1em);
    }
    P{
        display: inline-block;
        color: greenyellow;
        font-family: "Roboto";
        font-style: normal;
        font-weight: 300;
        font-size: 15px;
        line-height: 14px;
        margin-left: -3.5em;
    }
</style>
