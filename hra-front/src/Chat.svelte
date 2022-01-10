<script>
    import Message from "./Message.svelte";

    let visible=true;
    function hide(){ visible=!visible; console.log("activated");}
</script>

<div id="root">
    <h3>Chat:</h3>
    <a href="#" on:click={hide}>Hide</a>
    <hr />
    <div id="chatbox" class={ visible ? '' : 'hide'}>
        <Message />
        <Message />
        <Message />
        <Message />
        <Message />
        <Message />
        <Message />
    </div>
</div>

<style>
    #root {
        margin-left: 0.75em;
        margin-top: 0em;
        width: max-content;
    }

    h3 {
        margin-left: 0%;
        width: max-content;
        font-family: "Roboto";
        font-style: normal;
        font-weight: normal;
        font-size: 18px;
        line-height: 14px;
        color: white;
        display: inline;
    }

    a {
        margin-left: 1em;
        color: white;
    }

    hr {
        border: 0.1px solid black;
        width: auto;
    }
    #chatbox {
        -ms-overflow-style: none; 
        scrollbar-width: none; 
        overflow-y: scroll;
        width: 17em;
        height: 20em;
    }
    .hide{
        visibility: hidden;
    }
    #chatbox::-webkit-scrollbar {
        display: none;
    }
</style>
