<script>
    export let nomarg=0;
</script>

<div id="df" class={!nomarg ? 'yemarg' : 'nomarg'}>
    <div id="box">
        <img src="./static/ava.png" alt="ava">
    </div>
    <h1>Player</h1>
    <h2>500 XP</h2>    
</div>

<style>
    #df {
        margin-top: 1em;
        width: max-content;
        display: inline-block;
        text-align: center;
    }
    #box {
        margin-left: 50%;
        transform: translateX(-50%);
        width: 2em;
        height: 2em;
        background: #23272a;
        border: 5px solid #5865f2;
        border-radius: 10px;
       padding: 0.5em;
    }
    img{
        width: 1.75em;
        height: 1.75em;
        text-align: center;
        vertical-align: middle;
    }

    h1 {
        font-family: "Roboto";
        font-style: normal;
        font-weight: 500;
        font-size: 1em;
        line-height: 14px;
        margin: 0%;
        margin-top: 0.5em;
        color: white;
    }

    h2 {
        font-family: "Roboto";
        font-style: normal;
        font-weight: 500;
        font-size: 1.2em;
        line-height: 1.5em;
        margin: 0%;
        margin-top: 0.25em;
        color: white    ;
    }

    .nomarg{
        margin-left: 0em;
    }
    .yemarg{
        margin-left: 2.2em;
    }

    /* p {
    font-family: "Roboto";
    font-style: normal;
    font-weight: 300;
    font-size: 14px;
    line-height: 24px;
    color: #99aab5;
    margin: 0%;
    margin-top: 0px;
    } */
</style>
