<script>
</script>

<main>
    <h1>TERVOB</h1>
    <div id="box">
        <div class="connect">
            <p>Start game</p>
            <input type="text" id="input-code" />
            <input type="button" id="input-connect" value="Connect" />
        </div>
        <hr>
        <div class="connect">
            <p>or</p>
            <input type="button" id="input-create" value="Create room" />
            <input type="button" id="input-instruction" value="Instruction" />
            <select id="input-select" >  
                <option value="value1">en</option>
                <option value="value2" selected>sk</option>
                <option value="value3">ru</option>
              </select>
        </div>
       <div id="other">
        <a href="#">Support author</a>
        <i>Copyright 2022</i>
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
    h1 {
        color: white;
        font-family: "Roboto";
        font-style: normal;
        font-weight: 900;
        font-size: 3em;
        line-height: 48px;
        text-align: center;
        margin-top: 5%;
    }
    #other{
        margin-top: 35%;
    }
    i{
        display: block;
    }
    hr{
        border: 1px solid #2c2f33;
    }
    #box {
        width: 26.5em;
        height: 30em;
        text-align: center;
        margin-left: 50%;
        transform: translateX(-50%);
        background: #23272a;
        border-radius: 10px;
        margin-top: 2em;
    }
    .connect {
        padding-top: 10%;
        padding-bottom: 5%;
    }
    #input-code {
        width: 30%;
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
    #input-connect {
        width: 25%;
        height: 15%;
        background: #ed4245;
        border-radius: 10px;
        font-family: "Roboto";
        font-style: normal;
        font-weight: normal;
        font-size: 1em;
        margin-left: 5%;
        color: white;
        border: none;
    }
    #input-connect:hover {
        background: rgb(192, 28, 31);
        cursor: pointer;
    }
    #input-connect:active {
        background: rgb(124, 2, 4);
       
    }
    #input-create {
        width: 25%;
        height: 10%;
        background: #2686fb;
        border-radius: 10px;
        font-family: "Roboto";
        font-style: normal;
        font-weight: normal ;
        font-size: 1em;
        color: white;
        border: none;
    }
    #input-create:hover {
        background: #1064ca;
        cursor: pointer;
    }
    #input-create:active {
        background: #033470;
       
    }
    #input-instruction {
        width: 25%;
        height: 10%;
        background: #40454b;
        border-radius: 10px;
        font-family: "Roboto";
        font-style: normal;
        font-weight: normal;
        font-size: 1em;
        margin-left: 5%;
        color: white;
        border: none;
    }
    #input-instruction:hover {
        background: #3a3d41;
        cursor: pointer;
    }
    #input-instruction:active {
        background: rgb(40, 41, 43);
        
    }
    p {
        margin-top: -10%;
        font-family: "Roboto";
        font-style: normal;
        font-weight: 500;
        font-size: 1.5em;
        line-height: 48px;
        color: #717981;
    }
    #input-select {
        width: 20%;
        height: 10%;
        background: #40454b;
        border-radius: 10px;
        font-family: "Roboto";
        font-style: normal;
        font-weight:normal;
        font-size: 1em;
        margin-left: 5%;
        color: white;
        border: none;
    }
    #input-select:hover {
        background: #3a3d41;
        cursor: pointer;
    }
    #input-select:active {
        background: rgb(40, 41, 43);
    }
    #input-select:focus {
        outline: none;
    }
    option{
       border: none;
       outline: none;
    }
     
</style>
