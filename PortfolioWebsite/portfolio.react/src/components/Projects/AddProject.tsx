import React, { FormEvent, useState } from 'react';
import { Button, FormGroup, TextField } from '@material-ui/core';


const AddNewProject = () => {
    const [title, setTitle] = useState("");
    const [requirement, setRequirement] = useState("");
    const [design, setDesign] = useState("");
    const [completionDate, setCompletionDate] = useState("");

    function EditingTitle(e: React.ChangeEvent<HTMLInputElement>){
        setTitle(e.target.value);
        console.log(title);
    }

    function HandleSubmit(e: FormEvent<HTMLFormElement>){
        e.preventDefault();
        console.log("Title=" + title + "\n" +
                    "Requirement=" + requirement + "\n" +
                    "Design=" + design + "\n" +
                    "Date=" + completionDate);

        PostToAPI();
    }

    function PostToAPI(){
        console.log("You're about to post")
    }

    function GoBack(){
        console.log("You're in go back!")
    }

    return (
        <div id="AddProject">
            <form onSubmit={HandleSubmit}>
                <h4>Add new project:</h4>
                <TextField  value={title}
                            onChange={EditingTitle}
                            label={"Title:"}
                            placeholder={"Enter new title"}
                            required={true}
                            autoFocus={true}
                            variant="outlined"/>  
                <TextField  value={requirement}
                            onChange={(e) => setRequirement(e.target.value)}
                            label={"Requirement:"}
                            placeholder={"Please enter the requirements for the project"}                                                    
                            variant="outlined"
                            fullWidth
                            margin={"normal"}
                            multiline/>      
                <TextField  value={design}
                            onChange={(e) => setDesign(e.target.value)}
                            label={"Design:"}
                            placeholder={"Please enter the design of the project"}                                                    
                            variant="outlined"
                            fullWidth
                            margin={"normal"}
                            multiline/> 
                {/* <TextField  
                            onChange={(e) => setCompletionDate(e.target.value)}
                            label={"Completion Date:"}                                                                                
                            variant="outlined"
                            type="date"
                            margin={"normal"}
                            
                            /> */}
                <br/>
                <FormGroup row>
                    <Button variant="contained" color="primary" type="submit" >
                        Add New Project
                    </Button>
                    <p>                     </p>
                    <Button variant="contained" color="inherit" type="button" onClick={GoBack}>
                        Cancel
                    </Button>     
                </FormGroup>
                
            </form>
        </div>
    );
}

export default AddNewProject;