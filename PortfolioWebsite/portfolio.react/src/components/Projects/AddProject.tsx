import React, { FormEvent, useState } from 'react';
import { Button, TextField } from '@material-ui/core';

const AddNewProject = () => {
    const [title, setTitle] = useState("");
    const [requirement, setRequirement] = useState("");
    const [design, setDesign] = useState("");
    const [completionDate, setCompletionDate] = useState(() => {new Date().getDate()});



    function EditingTitle(e: React.ChangeEvent<HTMLInputElement>){
        setTitle(e.target.value);
        console.log(title);
    }

    function HandleSubmit(e: FormEvent<HTMLFormElement>){
        e.preventDefault();
        console.log("Title=" + title);
        console.log("Requirement=" + requirement);
        console.log("Design=" + design);
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
                {/* <TextField  value={completionDate}
                            onChange={(e) => setCompletionDate(new Date(e.target.value))}
                            label={"CompletionDate:"}
                            placeholder={"Please enter the completion date of the project"}                                                    
                            variant="outlined"
                            type={"date"}
                            margin={"normal"}
                            multiline/>       */}
                <Button     variant="contained" color="primary" type="submit">
                        Add New Project
                    </Button> 
            </form>
        </div>
    );
}

export default AddNewProject;