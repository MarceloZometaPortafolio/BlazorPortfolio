import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Button, Card, CardContent, CardHeader, Container, Paper } from '@material-ui/core';
import { AddCircle } from '@material-ui/icons';
import AddNewProject from './AddProject';
import {getProjects} from '../../Data/APIService';
import Project from '../../Models/Project';
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
                <Can
                    role={user.role}
                    perform="posts:create"
                    yes={()=>(
                        <div>
                         <Card className={classes.body}>                
                             <CardContent>
                                 <CardHeader title="Projects"/>     
                                 <Container maxWidth="sm">
                                    {projects.map((item) => 
                                        <div key={item.id}>
                                            {item.title}
                                            <Button>Edit</Button> 
                                            <Button>Delete</Button> 
                                        </div>)}    
                                </Container>                                       
                            </CardContent>                
                        </Card>         
                        <Button variant="contained" color="primary" startIcon={<AddCircle/>}
                                onClick={()=> setAddButtonWasClicked(!addButtonWasClicked)}
                        >
                            Add New Project
                        </Button>    
                    </div>
                    )}

                    no={()=>(
                        <div>
                         <Card className={classes.body}>                
                             <CardContent>
                                 <CardHeader title="Projects"/>     
                                 <Container maxWidth="sm">
                                    {projects.map((item) => 
                                        <div key={item.id}>
                                            {item.title}                                            
                                        </div>)}            
                                </Container>                                       
                            </CardContent>                
                        </Card>                                     
                    </div>
                    )}
                />
            )}
        </AuthConsumer>
        </div>
    );
}

// {addButtonWasClicked ? 
//     //True
//     <AddNewProject />
//     :
//     //False
//     <div>
//         <Card className={classes.body}>                
//             <CardContent>
//                 <CardHeader title="Projects"/>     
//                 <Container maxWidth="sm">
//                     {projects.map((item : Project) => 
//                         <div key={item.id}>{item.title}</div>)}            
//                 </Container>                                       
//             </CardContent>                
//         </Card>         
//         <Button variant="contained" color="primary" startIcon={<AddCircle/>}
//                 onClick={()=> setAddButtonWasClicked(!addButtonWasClicked)}
//         >
//             Add New Project
//         </Button>    
//     </div>
// }
// const ProjectsPage = () => (
//     <AuthConsumer>
//         {({ user }) => (
//             <Can
//                 role={user.role}
//                 perform="posts:create"
//                 yes={()=>(
//                     <div>
//         //             <Card className={classes.body}>                
//         //                 <CardContent>
//         //                     <CardHeader title="Projects"/>     
//         //                     <Container maxWidth="sm">
//         //                         {projects.map((item : Project) => 
//                                     <div key={item.id}>{item.title}</div>)}            
//                             </Container>                                       
//                         </CardContent>                
//                     </Card>         
//                     <Button variant="contained" color="primary" startIcon={<AddCircle/>}
//                             onClick={()=> setAddButtonWasClicked(!addButtonWasClicked)}
//                     >
//                         Add New Project
//                     </Button>    
//                 </div>
//                 )}
//             />
//         )}
//     </AuthConsumer>
// );

export default Projects;