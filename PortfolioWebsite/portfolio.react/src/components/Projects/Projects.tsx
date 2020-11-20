import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Button, Card, CardContent, CardHeader, Container, Paper } from '@material-ui/core';
import { AddCircle } from '@material-ui/icons';
import AddNewProject from './AddProject';
import {getProjects} from '../../Data/APIService';
import Project from '../../Models/Project';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
    body: {
      textAlign : "left"
    },
  }));


const Projects = () => {
    const [projects, setProjects] = useState([]);
    const [addButtonWasClicked, setAddButtonWasClicked] = useState(false);
    const classes = useStyles();
    // let mainFeaturedPost = {
    //     title: "",
    //     description:
    //       "Multiple lines of text that form the lede, informing new readers quickly and efficiently about what's most interesting in this post's contents.",
    //     image: 'https://source.unsplash.com/random',
    //     imageText: 'main image description',
    //     linkText: 'Continue reading…',
    //   };

    // async function getProjects(){
    //     return axios.get("https://portfolio-api-marcelo.herokuapp.com/api/project/")
    //         .then(response => {
    //             const projectsFound =  response.data;
    //             console.log(projectsFound);
    //             return projectsFound;
    //         })
    // }     

    useEffect(() => {
        async function fetchData () {
            const projectsReturned = await getProjects();
            
            setProjects(projectsReturned);
        }

        fetchData();
    }, []);

    return (
        <div id="Projects">
            {addButtonWasClicked ? 
                //True
                <AddNewProject />
                :
                //False
                <div>
                    <Card className={classes.body}>                
                        <CardContent>
                            <CardHeader title="Projects"/>     
                            <Container maxWidth="sm">
                                {projects.map((item : Project) => 
                                    <div key={item.id}>{item.title}</div>)}            
                            </Container>                                       
                        </CardContent>                
                    </Card>         
                    <Button variant="contained" color="primary" startIcon={<AddCircle/>}
                            onClick={()=> setAddButtonWasClicked(!addButtonWasClicked)}
                    >
                        Add New Project
                    </Button>    
                </div>
            }
        </div>
    );
}

export default Projects;