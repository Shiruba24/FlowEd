import React, { ChangeEvent, SyntheticEvent, useState } from "react";
import { Login } from "../models/users";
import { Button, Card, Form, Input, Typography, notification } from "antd";
import { Content } from "antd/es/layout/layout";

import { signInUser } from "../redux/slice/userSlice";
import { useAppDispatch } from "../redux/store/configureStore";

interface Props {
    toggleRegister: () => void;
}

const Signin = ({ toggleRegister }: Props) => {
    const [values, setValues] = useState<Login>({
        email: "",
        password: ""
    });
    const { Title, Text } = Typography;
    const { email, password } = values;

    const dispatch = useAppDispatch();
    const [form] = Form.useForm();
    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setValues({ ...values, [name]: value });
    };

    const resetForm = () => {
        setValues({ ...values, email: "", password: "" });
        form.resetFields();
    };

    const submitUser = async (e: SyntheticEvent) => {
        e.preventDefault();

        try {
            if (email.match(/^[^\s@]+@[^\s@]+\.[^\s@]+$/) && password.length >= 6) {
                await dispatch(signInUser(values));
            }
        } catch (error) {
            notification.error({
                message: "Please enter a valid email and password"
            });
            resetForm();
        }



    };

    return (
        <Card className="log-in-card">
            <div className="log-in-card__intro">
                <Typography>
                    <Title level={2} className="log-in-card__intro-title">Log in to Learnify</Title>
                    <Text>Use your Email and Password to Login!</Text>
                </Typography>
            </div>
            <Content className="log-in__form">
                <Form name="login"
                    labelCol={{ span: 8 }}
                    wrapperCol={{ span: 16 }}
                    autoComplete="off"
                    onSubmitCapture={submitUser}
                    form={form}
                >
                    <Form.Item label="Email" name="email"
                        rules={[{
                            required: true,
                            message: "Please enter a valid email!",
                            pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/
                        }]}
                    >
                        <Input value={email} name="email" onChange={handleChange}></Input>
                    </Form.Item>

                    <Form.Item label="Password" name="password"
                        rules={[{
                            required: true,
                            message: "Please enter a valid assword!",
                            min: 6,
                            max: 20
                        }]}
                    >
                        <Input.Password value={password} name="password" onChange={handleChange}></Input.Password>
                    </Form.Item>
                    <Form.Item wrapperCol={{ offset: 4, span: 16 }}>
                        <Button onClick={submitUser} type="primary" htmlType="submit">Submit</Button>
                    </Form.Item>

                </Form>
            </Content>
            <div onClick={toggleRegister} className="log-in-card__toggle">
                Not a sure yet? Register here
            </div>
        </Card>
    );
};




export default Signin;