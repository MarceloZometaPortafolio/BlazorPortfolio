import React, { useEffect, useState } from 'react';
import { Button, Card, CardContent, CardHeader, Container } from '@material-ui/core';
import { AddCircle } from '@material-ui/icons';
import AddNewProject from './AddProject';
import {getProjects} from '../../Data/APIService';
import { makeStyles } from '@material-ui/core/styles';
import { AuthConsumer } from '../../authContext';
import Can from '../../Can';

const useStyles = makeStyles((theme) => ({
    body: {
      textAlign : "left"
    },
  }));


const Projects = () => {
    const classes = useStyles();      
    const [projects, setProjects] = useState([]);
    const [addButtonWasClicked, setAddButtonWasClicked] = useState(false);

    useEffect(() => {
        async function fetchData () {
            const projectsReturned = await getProjects();
            
            setProjects(projectsReturned);
        }

        fetchData();
    }, []);

    return (
        <div id="Projects">
        <AuthConsumer>
            {({ user }) => (
                <div>
                    <Card className={classes.body}>                
                        <CardContent>
                            <CardHeader title="Projects"/>     
                                <Container maxWidth="sm">
                                {projects.map((item) => 
                                    <div key={item.id}>
                                        {item.title}
                                        <Can
                                            role={user.role}
                                            perform="posts:edit"
                                            yes={()=>(
                                                <Button>Edit</Button> 
                                            )}
                                        />
                                        <Can
                                            role={user.role}
                                            perform="posts:delete"
                                            yes={()=>(
                                                <Button>Delete</Button> 
                                            )}
                                        />
                                    </div>)}    
                                </Container>                                       
                        </CardContent>
                        <Can
                            role={user.role}
                            perform="posts:create"
                            yes={()=>(
                                <Button variant="contained" color="primary" startIcon={<AddCircle/>}
                                    onClick={()=> setAddButtonWasClicked(!addButtonWasClicked)}>
                                        Add New Project
                                </Button> 
                            )}
                        />                
                    </Card> 
                </div>)}
        </AuthConsumer>
        </div>
    );
}

export default Projects;