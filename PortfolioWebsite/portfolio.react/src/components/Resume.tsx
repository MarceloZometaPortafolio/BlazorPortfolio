import React from 'react'
import { makeStyles } from '@material-ui/core/styles';
import { CssBaseline } from '@material-ui/core';
import Iframe from 'react-iframe';

const useStyles = makeStyles((theme) => ({
    body: {
      backgroundColor: theme.palette.background.paper,
      // marginTop: theme.spacing(8),
      position: "relative",
      left: 0,
      bottom: 0,
      right: 0,  
      minHeight: "100vh"  
    },
  }));

const Resume = () => {
    const classes = useStyles();
    return (
        <><CssBaseline />
            <div className={classes.body}>
                <h2>Resume</h2>
                <Iframe url="marcelo_zometa_resume.pdf"
                    width="1500px"
                    height="1000px"
                    id="myId"
                    className="myClassname"                    
                    />
            </div></>
    );
}

export default Resume